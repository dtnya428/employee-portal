using EmployeePortal.DTOs.EmployeesDTOs;
using EmployeePortal.Services.EmployeesService;
using Microsoft.AspNetCore.Mvc;


namespace EmployeePortal.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeesService employeesService) : ControllerBase
    {
        public IEmployeesService employeesService = employeesService;

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            return Ok(await employeesService.GetAllAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var employeeResult = await employeesService.GetByIdAsync(id, cancellationToken);
                if (employeeResult != null)
                {
                    return Ok(employeeResult);
                }
                else
                {
                    return NotFound("Id was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTOIn newEmployee)
        {
            await employeesService.CreateAsync(newEmployee);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeDTOIn updatedInformation)
        {
            await employeesService.UpdateAsync(id, updatedInformation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await employeesService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("AddOffering")]
        public async Task<IActionResult> AddOfferingToEmployee([FromQuery] Guid employeeId, [FromQuery] Guid offeringId)
        {
            try
            {
                await employeesService.AddOfferingToEmployeeAsync(offeringId, employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("AddSkill")]
        public async Task<IActionResult> AddSkillToEmployee([FromQuery] Guid employeeId, [FromQuery] Guid skillId)
        {
            try
            {
                await employeesService.AddSkillToEmployeeAsync(skillId, employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("Detailed/{id}")]
        public async Task<IActionResult> GetEmployeeWithRelatedById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var employeeResult = await employeesService.GetByIdWithRelatedAsync(id, cancellationToken);
                if (employeeResult != null)
                {
                    return Ok(employeeResult);
                }
                else
                {
                    return NotFound("Id was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
