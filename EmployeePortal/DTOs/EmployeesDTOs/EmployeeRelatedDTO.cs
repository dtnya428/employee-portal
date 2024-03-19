using EmployeePortal.DTOs.OfferingsDTOs;
using EmployeePortal.DTOs.SkillsDTOs;

namespace EmployeePortal.DTOs.EmployeesDTOs
{
    public class EmployeeRelatedDTO
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public ICollection<OfferingsDTO>? Offerings { get; set; }
        public ICollection<SkillsDTO>? Skills { get; set; }
    }
}
