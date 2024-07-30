using FcCupApi.Contexts;
using FcCupApi.Models;
using FcCupApi.Services;
using mailService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize]
        [Route("create-forum")]
        public async Task<IActionResult> CreateForum(string title)
        {
            var username = User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null)
                return BadRequest("User not found");

            await _context.AddAsync<Forum>(new Forum() { 
                Title = title, 
                PublishedDateTime = DateTime.UtcNow, 
                AuthorDisplayName = user.DisplayName, 
                NumberOfComments = 0 });

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("get-forums")]
        public async Task<IActionResult> GetForums(int pageNumber = 1, int pageSize = 10)
        {
            var forums = await _context.Forums
                .OrderBy(c => c.PublishedDateTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(forums);
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

            var username = User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null)
                return BadRequest("Invalid user");

            if (parrentCommentId != null)
            {
                var parrentComment = await _context.FindAsync<Comment>(parrentCommentId);
                if (parrentComment == null)
                    return BadRequest("Invalid parrent comment Id");
            }

            var comment = new Comment() 
            {
                IsDeleted = false, 
                AuthorId = user!.Id, 
                CommentText = text,
                PublishedDateTime = DateTime.UtcNow, 
                Rating = 0, 
                ForumId = forumId,
                CommentId = parrentCommentId
            };

            var res = await _context.AddAsync(comment);
            forum.NumberOfComments++;
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

            var username = User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);
            if (user == null)
                return BadRequest("Invalid Token");

            var existingRating = await _context.CommentRatings
                .FirstOrDefaultAsync(cr => 
                    cr.CommentId == commentId 
                    && cr.UserId == user.Id);

            if (existingRating != null)
            {
                // Убираем оценку, если она совпадает с текущей
                if (existingRating.Rate == rate)
                {
                    ratedComment.Rating -= rate;
                    _context.CommentRatings.Remove(existingRating);
                }
                else
                {
                    // Меняем оценку
                    ratedComment.Rating += 2 * rate; // учитываем изменение оценки (например, с -1 на 1 это +2)
                    existingRating.Rate = rate;
                }
            }
            else
            {
                // Добавляем новую оценку
                ratedComment.Rating += rate;
                var commentRating = new CommentRating
                {
                    CommentId = commentId,
                    UserId = user.Id,
                    Rate = rate
                };
                await _context.CommentRatings.AddAsync(commentRating);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("${forumId}")]
        public async Task<IActionResult> GetComments(int forumId, int? parentCommentId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Comments
                .Where(c => c.ForumId == forumId && c.IsDeleted == false);

            query = parentCommentId.HasValue ? 
                query.Where(c => c.CommentId == parentCommentId.Value) 
                : query.Where(c => c.CommentId == null);

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
