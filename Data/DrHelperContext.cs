using DrHelperBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DrHelperBack.Data
{
    public class DrHelperContext : DbContext
    {
        public DrHelperContext(DbContextOptions<DrHelperContext> opt) : base(opt) { }
        public DbSet<UserType> user_type { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Disease> disease { get; set; }
        public DbSet<Medicine> medicine { get; set; }
    }
}
