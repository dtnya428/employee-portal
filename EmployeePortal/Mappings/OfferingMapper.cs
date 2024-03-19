using EmployeePortal.DTOs.OfferingsDTOs;
using EmployeePortal.Models;

namespace EmployeePortal.Mappings
{
    public static class OfferingMapper
    {
        public static OfferingsDTO MapToDTO(Offering offering) => new()
        {
            Id = offering.Id,
            BusinessUnit = offering.BusinessUnit,
            PrimaryOffering = offering.PrimaryOffering,
            SecondaryOffering = offering.SecondaryOffering,
            Tribe = offering.Tribe
        };

        public static Offering MapFromDTO(OfferingsDTO offeringsDTO) => new()
        {
            Id = offeringsDTO.Id,
            BusinessUnit = offeringsDTO.BusinessUnit,
            PrimaryOffering = offeringsDTO.PrimaryOffering,
            SecondaryOffering = offeringsDTO.SecondaryOffering,
            Tribe = offeringsDTO.Tribe
        };

        public static OfferingDTOIn MapToInsertDTO(Offering offering) => new()
        {
            BusinessUnit = offering.BusinessUnit,
            PrimaryOffering = offering.PrimaryOffering,
            SecondaryOffering = offering.SecondaryOffering,
            Tribe = offering.Tribe
        };

        public static Offering MapFromDTO(OfferingDTOIn offeringDTOIn) => new()
        {
            BusinessUnit = offeringDTOIn.BusinessUnit,
            PrimaryOffering = offeringDTOIn.PrimaryOffering,
            SecondaryOffering = offeringDTOIn.SecondaryOffering,
            Tribe = offeringDTOIn.Tribe
        };
    }
}
