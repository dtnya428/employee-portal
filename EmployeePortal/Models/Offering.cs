namespace EmployeePortal.Models
{
    public class Offering : BaseModel
    {
        public required string BusinessUnit { get; set; }
        public required string PrimaryOffering { get; set; }
        public required string SecondaryOffering { get; set; }
        public string? Tribe { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
