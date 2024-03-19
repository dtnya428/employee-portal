using EmployeePortal.DTOs.OfferingsDTOs;

namespace EmployeePortal.Services.OfferingsService
{
    public interface IOfferingsService
    {
        Task<IEnumerable<OfferingsDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<OfferingsDTO?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(OfferingDTOIn entity);
        Task UpdateAsync(Guid id, OfferingDTOIn entity);
        Task DeleteAsync(Guid id);
    }
}
