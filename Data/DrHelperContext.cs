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
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionsMedicine> PrescriptionsMedicine { get; set; }
        public DbSet<UsersPrescriptions> UsersPrescriptions { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionsMedicine>()
                .HasKey(o => new { o.idPrescription, o.idMedicine });
            modelBuilder.Entity<UsersPrescriptions>()
                .HasKey(o => new { o.idUser, o.idPrescription });
        }
    }
}
