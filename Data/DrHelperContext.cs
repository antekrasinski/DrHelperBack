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

        public DbSet<Perscription> Perscription { get; set; }
        public DbSet<PerscriptionsMedicine> PerscriptionsMedicine { get; set; }
        public DbSet<UsersPerscriptions> UsersPerscriptions { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersDiseases>()
                .HasKey(o => new { o.idUser, o.idDisease });
            modelBuilder.Entity<PerscriptionsMedicine>()
                .HasKey(o => new { o.idPerscription, o.idMedicine });
            modelBuilder.Entity<UsersPerscriptions>()
                .HasKey(o => new { o.idUser, o.idPerscription });
        }
    }
}
