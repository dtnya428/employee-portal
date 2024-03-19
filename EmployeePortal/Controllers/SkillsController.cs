using EmployeePortal.DTOs.SkillsDTOs;
using EmployeePortal.Services.SkillsServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController(ISkillsService skillsService) : ControllerBase
    {
        public ISkillsService _skillsService = skillsService;

        [HttpGet()]
        public async Task<IActionResult> GetAllSkill(CancellationToken cancellationToken)
        {
            return Ok(await _skillsService.GetAllAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var skill = await _skillsService.GetByIdAsync(id, cancellationToken);
                if (skill == null)
                {
                    return NotFound("Skill with this id not found");
                }
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddSkill([FromBody] InsertSkillsDTO skill)
        {
            await _skillsService.CreateAsync(skill);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            await _skillsService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(Guid id, [FromBody] InsertSkillsDTO skill)
        {
            try
            {
                if (skill != null)
                {
                    await _skillsService.Update(id, skill);
                    return Ok();
                }
                return BadRequest("Invalid request");
            }
            catch (Exception)
            {
                return BadRequest("Skill with this id does not exist");
            }
        }
    }
}
