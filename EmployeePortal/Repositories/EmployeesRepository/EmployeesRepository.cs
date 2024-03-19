using EmployeePortal.Models;
using EmployeePortal.DataContext;

namespace EmployeePortal.Repositories.EmployeesRepository
{
    public class EmployeesRepository(EmployeeContext context) : GenericRepository<Employee>(context), IEmployeesRepository
    {
        public async Task AddOfferingToEmployeeAsync(Guid offeringId, Guid employeeId)
        {
            Employee employee = await context.Employees.FindAsync(employeeId) ?? throw new Exception("Employee not found");
            Offering offering = await context.Offerings.FindAsync(offeringId) ?? throw new Exception("Offering not found");
            employee.Offerings?.Add(offering);
            await context.SaveChangesAsync();
        }

        public async Task AddSkillToEmployeeAsync(Guid skillId, Guid employeeId)
        {
            Employee employee = await context.Employees.FindAsync(employeeId) ?? throw new Exception("Employee not found");
            Skill skill = await context.Skills.FindAsync(skillId) ?? throw new Exception("Skill not found");
            employee.Skills?.Add(skill);
            await context.SaveChangesAsync();
        }
    }
}
