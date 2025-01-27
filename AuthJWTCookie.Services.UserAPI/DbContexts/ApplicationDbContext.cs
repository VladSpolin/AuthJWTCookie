using AuthJWTCookie.Services.UserAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace AuthJWTCookie.Services.UserAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

    }
}
