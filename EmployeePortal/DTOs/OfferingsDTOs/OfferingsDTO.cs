﻿namespace EmployeePortal.DTOs.OfferingsDTOs
{
    public class OfferingsDTO
    {
        public Guid Id { get; set; }
        public required string BusinessUnit { get; set; }
        public required string PrimaryOffering { get; set; }
        public required string SecondaryOffering { get; set; }
        public string? Tribe { get; set; }
    }
}
