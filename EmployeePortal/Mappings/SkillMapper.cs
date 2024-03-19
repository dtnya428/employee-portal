using EmployeePortal.DTOs.SkillsDTOs;
using EmployeePortal.Models;

namespace EmployeePortal.Mappings
{
    public static class SkillMapper
    {
        public static SkillsDTO MapToDTO(Skill skill) => new()
        {
            Id = skill.Id,
            Name = skill.Name,
            Description = skill.Description
        };

        public static Skill MapFromDTO(SkillsDTO skillsDTO) => new()
        {
            Id = skillsDTO.Id,
            Name = skillsDTO.Name,
            Description = skillsDTO.Description
        };

        public static InsertSkillsDTO MapToInsertDTO(Skill skill) => new()
        {
            Name = skill.Name,
            Description = skill.Description
        };

        public static Skill MapFromDTO(InsertSkillsDTO insertSkillsDTO) => new()
        {
            Name = insertSkillsDTO.Name,
            Description = insertSkillsDTO.Description
        };

    }
}
