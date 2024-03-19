using EmployeePortal.DataContext;
using EmployeePortal.Models;

namespace EmployeePortal.Repositories.SkillsRepository
{
    public class SkillsRepository(EmployeeContext context) : GenericRepository<Skill>(context), ISkillsRepository
    {
    }
}
