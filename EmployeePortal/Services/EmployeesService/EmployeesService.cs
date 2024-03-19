using EmployeePortal.DTOs.EmployeesDTOs;
using EmployeePortal.Mappings;
using EmployeePortal.Models;
using EmployeePortal.Repositories.EmployeesRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Services.EmployeesService
{
    public class EmployeesService(IEmployeesRepository employeesRepository) : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository = employeesRepository;

        public async Task<IEnumerable<EmployeesDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _employeesRepository
                .GetAllAsync()
                .Select(employee => EmployeeMapper.MapToDTO(employee))
                .ToListAsync(cancellationToken);
        }

        public async Task<EmployeesDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var employeeResult = await _employeesRepository.GetByIdAsync(id);
            if (employeeResult != null)
            {
                return EmployeeMapper.MapToDTO(employeeResult);
            }
            return null;
        }

        public async Task CreateAsync(EmployeeDTOIn employeeDTOIn)
        {
            Employee addEmployee = EmployeeMapper.MapFromDTO(employeeDTOIn);
            addEmployee.CreatedDate = DateTime.Now;
            addEmployee.UpdatedDate = DateTime.Now;
            await _employeesRepository.CreateAsync(addEmployee);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _employeesRepository.SoftDelete(id);
        }

        public async Task UpdateAsync(Guid id, EmployeeDTOIn employeeDTOIn)
        {
            var updateEmployee = await _employeesRepository.GetByIdAsync(id);
            if (updateEmployee != null)
            {
                updateEmployee.FirstName = employeeDTOIn.FirstName;
                updateEmployee.MiddleName = employeeDTOIn.MiddleName;
                updateEmployee.LastName = employeeDTOIn.LastName;
                updateEmployee.Email = employeeDTOIn.Email;
                updateEmployee.Mobile = employeeDTOIn.Mobile;
                updateEmployee.UpdatedDate = DateTime.Now;
                await _employeesRepository.Update(updateEmployee);
            }
        }

        public async Task AddOfferingToEmployeeAsync(Guid offeringId, Guid employeeId)
        {
            await _employeesRepository.AddOfferingToEmployeeAsync(offeringId, employeeId);
        }

        public async Task AddSkillToEmployeeAsync(Guid skillId, Guid employeeId)
        {
            await _employeesRepository.AddSkillToEmployeeAsync(skillId, employeeId);
        }

        public async Task<EmployeeRelatedDTO?> GetByIdWithRelatedAsync(Guid id, CancellationToken cancellationToken)
        {
            var employeeResult = await _employeesRepository.GetByIdAsync(id);
            if (employeeResult != null)
            {
                return EmployeeMapper.MapToRelatedDTO(employeeResult);
            }
            return null;
        }
    }
}
