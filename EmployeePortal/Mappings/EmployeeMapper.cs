using EmployeePortal.DTOs.EmployeesDTOs;
using EmployeePortal.Models;

namespace EmployeePortal.Mappings
{
    public static class EmployeeMapper
    {
        public static EmployeesDTO MapToDTO(Employee employee) => new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            Mobile = employee.Mobile,
            Email = employee.Email
        };

        public static Employee MapFromDTO(EmployeesDTO employeesDTO) => new()
        {
            Id = employeesDTO.Id,
            FirstName = employeesDTO.FirstName,
            MiddleName = employeesDTO.MiddleName,
            LastName = employeesDTO.LastName,
            Mobile = employeesDTO.Mobile,
            Email = employeesDTO.Email
        };

        public static EmployeeDTOIn MapToInsertDTO(Employee employee) => new()
        {
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            Mobile = employee.Mobile,
            Email = employee.Email
        };

        public static Employee MapFromDTO(EmployeeDTOIn employeeDTOIn) => new()
        {
           FirstName = employeeDTOIn.FirstName,
           MiddleName= employeeDTOIn.MiddleName,
           LastName = employeeDTOIn.LastName,
           Mobile = employeeDTOIn.Mobile,
           Email = employeeDTOIn.Email
        };

        public static EmployeeRelatedDTO MapToRelatedDTO(Employee employee) => new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            Mobile = employee.Mobile,
            Email = employee.Email,
            Offerings = employee.Offerings?.Select(o => OfferingMapper.MapToDTO(o)).ToList(),
            Skills = employee.Skills?.Select(s => SkillMapper.MapToDTO(s)).ToList()
        };
    }
}
