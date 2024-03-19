using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePortal.DataContext.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MiddleName)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasMaxLength(50);

            builder.Property(x => x.Mobile)
                .HasMaxLength(10);

            builder.HasData(
                new Employee { Id = Guid.NewGuid(), FirstName = "Nico", MiddleName = "Jared", LastName = "Govindsamy", Email = "njg@gmail.com", Mobile = "1010101000" },
                new Employee { Id = Guid.NewGuid(), FirstName = "Test",  LastName = "Bob", Email = "bob@gmail.com"}
                ); 
        }
    }
}
