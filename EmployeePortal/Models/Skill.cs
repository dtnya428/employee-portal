namespace EmployeePortal.Models
{
    public class Skill : BaseModel
    {
        public required string Name { get; set; } 
        public required string Description { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
