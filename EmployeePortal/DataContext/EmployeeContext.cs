using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeePortal.DataContext
{
    public class EmployeeContext(DbContextOptions<EmployeeContext> options) : DbContext(options)
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Offering> Offerings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
