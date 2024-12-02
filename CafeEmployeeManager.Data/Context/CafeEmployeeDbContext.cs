using CafeEmployeeManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeEmployeeManager.Data.Context
{
    public class CafeEmployeeDbContext : DbContext
    {
        public CafeEmployeeDbContext(DbContextOptions<CafeEmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<EmployeeCafeAssignment> EmployeeCafeAssignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionStringHere");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Cafe>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<EmployeeCafeAssignment>()
                .HasKey(e => new { e.EmployeeId, e.CafeId });

            modelBuilder.Entity<EmployeeCafeAssignment>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeCafeAssignment>()
                .HasOne(e => e.Cafe)
                .WithMany()
                .HasForeignKey(e => e.CafeId);
        }
    }
}
