using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePortal.DataContext.Configurations
{
    public class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Employees)
                  .WithMany(e => e.Skills)
                  .UsingEntity(
                    l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                    r => r.HasOne(typeof(Skill)).WithMany().HasForeignKey("SkillId").HasPrincipalKey(nameof(Skill.Id)),
                    j => j.HasKey("SkillId", "EmployeeId")); ;

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
               .HasMaxLength(100);

            builder.HasData(
                new Skill { Id = Guid.NewGuid(), Name = "C#", Description = "Programming language" },
                new Skill { Id = Guid.NewGuid(), Name = "React", Description = "Frontend framework competency" },
                new Skill { Id = Guid.NewGuid(), Name = "Communication", Description = "verbal and written" },
                new Skill { Id = Guid.NewGuid(), Name = "Auditing", Description = "stuff" }
                );
        }
    }
}
