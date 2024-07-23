using FcCupApi.Contexts;
using FcCupApi.Extensions;
using FcCupApi.Models;
using FcCupApi.Models.Identity;
using FcCupApi.Services;
using mailService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Common;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using static System.Net.Mime.MediaTypeNames;

namespace FcCupApi.Controllers
{
    [ApiController]
    [Route("forum")]
    public class ForumController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly UsersDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly IMailService _mailService;
        private readonly SignInManager<User> _signInManager;

        public ForumController(
            ITokenService tokenService,
            UsersDbContext context,
            UserManager<User> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole<long>> roleManager,
            IMailService mailService,
            SignInManager<User> signInManager)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _mailService = mailService;
            _signInManager = signInManager;
        }

        [HttpPost]
        //[Authorize]
        [Route("create-forum")]
        public async Task<IActionResult> CreateForum(string title)
        {
            await _context.AddAsync<Forum>(new Forum() { Title = title });
            _context.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Authorize]
        [Route("publish-comment")]
        public async Task<IActionResult> PublishComment(string text, int forumId, int? parrentCommentId)
        {
            if (text == null)
                return BadRequest("Text should contains symbols");

            var forum = await _context.FindAsync<Forum>(forumId);
            if (forum == null)
                return BadRequest("Invalid forum Id");

            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            var accessToken = authHeader?.Split(" ").Last();
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);
            var username = principal!.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            var comment = new Comment() { 
                IsDeleted = false, 
                AuthorId = user!.Id, 
                CommentText = text,
                PublishedDateTime = DateTime.UtcNow, 
                Rating = 0, 
                ForumId = forumId,
                CommentId = parrentCommentId};

            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("delete-comment")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("rate-comment")]
        public async Task<IActionResult> RateComment(int commentId, int rate)
        {
            if (rate != 1 && rate != -1)
                return BadRequest("Rate of comment should be 1 or -1");

            var ratedComment = await _context.FindAsync<Comment>(commentId);
            if (ratedComment == null)
                return BadRequest("Invalid Comment Id");

            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            var accessToken = authHeader?.Split(" ").Last();
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);
            var username = principal!.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            ratedComment.Rating += rate;
            _context.SaveChanges();

            return Ok();

            //Один и тот же пользователь не может несколько раз оценивать один комментарий,
            //Нужно это как-то отслеживать
        }

        [HttpGet]
        [Route("get-comments")]
        public async Task<IActionResult> GetComments(int forumId, int? parentCommentId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Comments
                                .Where(c => c.ForumId == forumId && c.IsDeleted == false);

            if (parentCommentId.HasValue)
                query = query.Where(c => c.CommentId == parentCommentId.Value);
            else
                query = query.Where(c => c.CommentId == null);

            var comments = await query
                                .OrderBy(c => c.PublishedDateTime)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Ok(comments);
        }


        [HttpGet]
        [Route("get-replies")]
        public async Task<IActionResult> GetReplies(int parentCommentId, int pageNumber = 1, int pageSize = 10)
        {
            var replies = await _context.Comments
                                        .Where(c => c.CommentId == parentCommentId && c.IsDeleted == false)
                                        .OrderBy(c => c.PublishedDateTime)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return Ok(replies);
        }
    }
}
