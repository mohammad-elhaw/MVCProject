using Project.DAL.Entities.Shared;
using Project.DAL.Entities.Shared.Enums;

namespace Project.DAL.Entities.EmployeeEntity
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }  
    }
}
