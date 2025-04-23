using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Employee
{
    public record EmployeeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int? Age { get; init; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; init; }
        
        [Display(Name = "Is Active")]
        public bool IsActive { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
        public string Gender { get; init; }
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; init; }
        public string? Department { get; init; }
    }
}
