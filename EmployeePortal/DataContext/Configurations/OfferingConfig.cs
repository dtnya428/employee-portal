using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePortal.DataContext.Configurations
{
    public class OfferingConfig : IEntityTypeConfiguration<Offering>
    {
        public void Configure(EntityTypeBuilder<Offering> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Employees)
                  .WithMany(e => e.Offerings)
                  .UsingEntity(
                    l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                    r => r.HasOne(typeof(Offering)).WithMany().HasForeignKey("OfferingId").HasPrincipalKey(nameof(Offering.Id)),
                    j => j.HasKey("OfferingId", "EmployeeId"));

            builder.Property(x => x.BusinessUnit)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.PrimaryOffering)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.SecondaryOffering)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Tribe)
               .HasMaxLength(50);

            builder.HasData(
                new Offering { Id = Guid.NewGuid(), BusinessUnit = "Risk", PrimaryOffering = "Compliance", SecondaryOffering = "Regulation Commitee" },
                new Offering { Id = Guid.NewGuid(), BusinessUnit = "Auditing", PrimaryOffering = "CBO - Software Engineering", SecondaryOffering = "Application Development", Tribe = "Levvia Pod" },
                new Offering { Id = Guid.NewGuid(), BusinessUnit = "Finance", PrimaryOffering = "Accounting", SecondaryOffering = "Bookkeeping"}
                );
        }
    }
}
