using Doctors.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<Fees>().HasKey(f => f.FeeId);
        //    modelBuilder.Entity<Fees>()
        //   .Property(f => f.Amount)
        //   .HasColumnType("decimal(18, 2)");

        //    modelBuilder.Entity<Fees>()
        //     .Property(f => f.DoctorFeeAmount)
        //      .HasColumnType("decimal(18, 2)");

        //    modelBuilder.Entity<Fees>()
        //        .Property(f => f.DoctorFeeTotal)
        //        .HasColumnType("decimal(18, 2)");

        //    modelBuilder.Entity<Fees>()
        //        .Property(f => f.Total)
        //        .HasColumnType("decimal(18, 2)");
        //    base.OnModelCreating(modelBuilder);
        //}
        //public DbSet<Schedule> Schedules { get; set; }

        //public DbSet<Clinic> Clinics { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        //public DbSet<User> Users { get; set; }


    }
}
