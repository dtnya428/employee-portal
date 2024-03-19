using EmployeePortal.Models;

namespace EmployeePortal.Repositories.EmployeesRepository
{
    public interface IEmployeesRepository: IGenericRepository<Employee>
    {
        Task AddOfferingToEmployeeAsync(Guid offeringId, Guid employeeId);
        Task AddSkillToEmployeeAsync(Guid skillId, Guid employeeId);
    }
}
