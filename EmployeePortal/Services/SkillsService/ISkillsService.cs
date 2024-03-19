using EmployeePortal.DTOs.SkillsDTOs;

namespace EmployeePortal.Services.SkillsServices
{
    public interface ISkillsService
    {
       Task<IEnumerable<SkillsDTO>> GetAllAsync(CancellationToken cancellationToken);
       Task<SkillsDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
       Task CreateAsync(InsertSkillsDTO skillDTOIn);
       Task Delete(Guid id);
       Task Update(Guid id, InsertSkillsDTO inSkillDTO);
    }
}
