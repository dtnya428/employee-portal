﻿namespace EmployeePortal.DTOs.EmployeesDTOs
{
    public class EmployeeDTOIn
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}
