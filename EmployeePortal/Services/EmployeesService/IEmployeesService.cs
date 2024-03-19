using EmployeePortal.DTOs.EmployeesDTOs;

namespace EmployeePortal.Services.EmployeesService
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeesDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<EmployeesDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(EmployeeDTOIn employeeDTOIn);
        Task UpdateAsync(Guid id, EmployeeDTOIn employeeDTOIn);
        Task DeleteAsync(Guid id);
        Task AddOfferingToEmployeeAsync(Guid offeringId, Guid employeeId);
        Task AddSkillToEmployeeAsync(Guid skillId, Guid employeeId);
        Task<EmployeeRelatedDTO?> GetByIdWithRelatedAsync(Guid id, CancellationToken cancellationToken);
    }
}
