namespace EmployeePortal.DTOs.EmployeesDTOs
{
    public class EmployeesDTO
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}
