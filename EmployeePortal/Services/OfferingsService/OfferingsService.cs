using EmployeePortal.DTOs.OfferingsDTOs;
using EmployeePortal.Mappings;
using EmployeePortal.Models;
using EmployeePortal.Repositories.OfferingsRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Services.OfferingsService
{
    public class OfferingsService(IOfferingRepository offeringsRepository) : IOfferingsService
    {
        private readonly IOfferingRepository _offeringsRepository = offeringsRepository;

        public async Task CreateAsync(OfferingDTOIn offeringDTOIn)
        {
            Offering offering = OfferingMapper.MapFromDTO(offeringDTOIn);
            offering.CreatedDate = DateTime.Now;
            offering.UpdatedDate = DateTime.Now;
            await _offeringsRepository.CreateAsync(offering);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _offeringsRepository.SoftDelete(id);
        }

        public async Task<IEnumerable<OfferingsDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _offeringsRepository
                .GetAllAsync()
                .Select(offering => OfferingMapper.MapToDTO(offering))
                .ToListAsync(cancellationToken);
        }

        public async Task<OfferingsDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var offering = await _offeringsRepository.GetByIdAsync(id);
            if(offering != null)
            {
                return OfferingMapper.MapToDTO(offering);
            }
            return null;
        }

        public async Task UpdateAsync(Guid id, OfferingDTOIn entity)
        {
            var updateOffering = await _offeringsRepository.GetByIdAsync(id);
            if (updateOffering != null)
            {
                updateOffering.BusinessUnit = entity.BusinessUnit;
                updateOffering.PrimaryOffering = entity.PrimaryOffering;
                updateOffering.SecondaryOffering = entity.SecondaryOffering;
                updateOffering.Tribe = entity.Tribe;
                updateOffering.UpdatedDate = DateTime.Now;
                await _offeringsRepository.Update(updateOffering);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
    }
}
