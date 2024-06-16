using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Models.User> User { get; set; } = default!;
    }
}
