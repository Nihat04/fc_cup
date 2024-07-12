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

        DbSet<Comment> Comments { get; set; }
        DbSet<Forum> Forums { get; set; }
    }
}
