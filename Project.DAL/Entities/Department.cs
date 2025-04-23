using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Entities.Shared;

namespace Project.DAL.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
