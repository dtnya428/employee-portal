using EmployeePortal.DTOs.SkillsDTOs;
using EmployeePortal.Mappings;
using EmployeePortal.Models;
using EmployeePortal.Repositories.SkillsRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Services.SkillsServices
{
    public class SkillsService(ISkillsRepository skillsRepository) : ISkillsService
    {
        private readonly ISkillsRepository _skillsRepository = skillsRepository;

        public async Task<IEnumerable<SkillsDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _skillsRepository
                .GetAllAsync()
                .Select(skill => SkillMapper.MapToDTO(skill))
                .ToListAsync(cancellationToken);
        }

        public async Task<SkillsDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var skill = await _skillsRepository.GetByIdAsync(id);
            if (skill != null)
            {
                return SkillMapper.MapToDTO(skill);
            }
            return null;
        }

        public async Task CreateAsync(InsertSkillsDTO skillDTOIn)
        {
            Skill skill = SkillMapper.MapFromDTO(skillDTOIn);
            skill.CreatedDate = DateTime.Now;
            skill.UpdatedDate = DateTime.Now;
            await _skillsRepository.CreateAsync(skill);
        }

        public async Task Delete(Guid id)
        {
            await _skillsRepository.SoftDelete(id);
        }

        public async Task Update(Guid id, InsertSkillsDTO inSkillDTO)
        {
            var skill = await _skillsRepository.GetByIdAsync(id) ?? throw new Exception("Skill with this id does not exist");
            if (skill != null)
            {
                skill.Name = inSkillDTO.Name;
                skill.Description = inSkillDTO.Description;
                skill.UpdatedDate = DateTime.Now;
                await _skillsRepository.Update(skill);
            }
        }
    }
}

