using EmployeePortal.DTOs.OfferingsDTOs;
using EmployeePortal.Services.OfferingsService;
using Microsoft.AspNetCore.Mvc;


namespace EmployeePortal.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OfferingsController(IOfferingsService offeringsService) : ControllerBase
    {
        IOfferingsService offeringsService = offeringsService;

        [HttpGet]
        public async Task<IActionResult> GetAllOfferings(CancellationToken cancellationToken)
        {
            return Ok(await offeringsService.GetAllAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferingById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var offeringResult = await offeringsService.GetByIdAsync(id, cancellationToken);
                if (offeringResult != null)
                {
                    return Ok(offeringResult);
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
        public async Task<IActionResult> CreateOffering([FromBody] OfferingDTOIn offeringDTOIn)
        {
            await offeringsService.CreateAsync(offeringDTOIn);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOffering(Guid id, [FromBody] OfferingDTOIn offeringDTOIn)
        {
            await offeringsService.UpdateAsync(id, offeringDTOIn);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffering(Guid id)
        {
            await offeringsService.DeleteAsync(id);
            return Ok();
        }
    }
}
