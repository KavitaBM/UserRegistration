using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Models
{
    public class AppUserContext : DbContext
    {
        public AppUserContext(DbContextOptions<AppUserContext> options) : base(options)
        {
        }
        public DbSet<UserInfo> Users { get; set; }
    }
    
}
