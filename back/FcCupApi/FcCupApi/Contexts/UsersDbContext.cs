using FcCupApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FcCupApi.Contexts
{
    public class UsersDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<CommentRating> CommentRatings { get; set; }
    }
}
