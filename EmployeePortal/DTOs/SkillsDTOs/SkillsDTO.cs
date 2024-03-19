namespace EmployeePortal.DTOs.SkillsDTOs
{
    public class SkillsDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
