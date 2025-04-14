using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Employee
{
    public record EmployeeDetailsDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int? Age { get; init; }
        public string? Address { get; init; }
        public decimal Salary { get; init; }
        public bool IsActive { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public DateOnly HiringDate { get; init; }
        public string Gender { get; init; }
        public string EmployeeType { get; init; }
        public int CreatedBy { get; init; }
        public DateTime? CreatedOn { get; init; }
        public int LastModifiedBy { get; init; }
        public DateTime? LastModifiedOn { get; init; }
    }
}
