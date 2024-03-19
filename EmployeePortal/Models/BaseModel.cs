﻿namespace EmployeePortal.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

