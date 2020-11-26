using DrHelperBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DrHelperBack.Data
{
    public class DrHelperContext : DbContext
    {
        public DrHelperContext(DbContextOptions<DrHelperContext> opt) : base(opt) { }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Disease> Disease { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Timeblock> Timeblock { get; set; }
        public DbSet<UsersDiseases> UsersDiseases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersDiseases>()
                .HasKey(o => new { o.idUser, o.idDisease });
        }
    }
}
