namespace EmployeePortal.Models
{
    public class Employee : BaseModel
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public virtual ICollection<Offering>? Offerings { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
    }
}
