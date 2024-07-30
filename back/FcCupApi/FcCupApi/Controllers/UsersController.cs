using Microsoft.AspNetCore.Mvc;
using FcCupApi.Models;
using FcCupApi.Services;
using FcCupApi.Models.Identity;
using FcCupApi.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using FcCupApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using mailService.Services;
using mailService.Models;
using System.ComponentModel;

namespace FcCupApi.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly UsersDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly IMailService _mailService;

        public UsersController(ITokenService tokenService, 
            UsersDbContext context, 
            UserManager<User> userManager, 
            IConfiguration configuration, 
            RoleManager<IdentityRole<long>> roleManager,
            IMailService mailService)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var managedUser = await _userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
                return BadRequest("Bad credentials");

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
                return BadRequest("Bad credentials");

            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
                return Unauthorized();

            var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await _context.SaveChangesAsync();

            return Ok(new AuthenticateResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticateResponse>> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(request);

            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                RegistrationDateTime = DateTime.UtcNow,
                DisplayName = request.DisplayName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            if (!result.Succeeded) 
                return BadRequest(request);

            var findUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == request.Email);
            if (findUser == null) 
                throw new Exception($"User with email: {request.Email} not found");

            var roleExist = await _roleManager.RoleExistsAsync(RoleConsts.Member);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole<long>(RoleConsts.Member));
                await _roleManager.CreateAsync(new IdentityRole<long>(RoleConsts.Moderator));
                await _roleManager.CreateAsync(new IdentityRole<long>(RoleConsts.Administrator));
            }

            await _userManager.AddToRoleAsync(findUser, RoleConsts.Member);

            return await Authenticate(new AuthenticateRequest
            {
                Email = request.Email,
                Password = request.Password
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
                return BadRequest("Invalid client request");

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
                return BadRequest("Invalid access token or refresh token");

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return BadRequest("Invalid access token or refresh token");

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = $"{RoleConsts.Administrator}")]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) 
                return BadRequest("Invalid user name");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

            return Ok();
        }

        [HttpPost]
        [Route("send-confirm")]
        public async Task<IActionResult> SendAccountMailConfirmMessage([FromBody] EmailConfirmRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && (await _userManager.CheckPasswordAsync(user, request.Password)))
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (token == null)
                    return StatusCode(500);

                var callbackUrl = Url.Action("ConfirmEmail", "Users", new { userId = user.Id, code = token });
                var mailData = new MailData(new List<string>() { request.Email }, 
                    "Account Email Confirmation", 
                    $"Для подтверждения электронной почты пройдите по ссылке: " +
                    $"<a href='{_configuration["Host"]}{callbackUrl}'>link</a>");
                var mailActionResult = await _mailService.SendAsync(mailData);
                return mailActionResult ? Ok("Check your email") : StatusCode(500);
            }
            else
                return NotFound("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return NotFound();
            
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
                return Ok("Email has been confirmed!");
            else
                return NotFound();
        }


        [HttpGet]
        [Route("user-info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var username = User.Identity!.Name;
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
                return BadRequest("User not found");

            return new ObjectResult(new
            {
                Id = user.Id!,
                UserName = user.UserName!,
                DisplayName = user.DisplayName!,
                RegistrationDateTime = user.RegistrationDateTime!,
            });
        }

        [HttpGet]
        [Route("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.Identity!.Name;
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
                return BadRequest("User not found");

            var userRatingFromComments = _context.Comments
                .Where(x => x.AuthorId == user.Id)
                .Select(x => x.Rating)
                .Sum();

            return new ObjectResult(new
            {
                Id = user.Id!,
                UserName = user.UserName!,
                DisplayName = user.DisplayName!,
                RegistrationDateTime = user.RegistrationDateTime!,
                Rating = userRatingFromComments
            });
        }
    }
}
