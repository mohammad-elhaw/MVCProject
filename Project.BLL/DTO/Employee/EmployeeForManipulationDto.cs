using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Employee
{
    public abstract record EmployeeForManipulationDto
    {
        [MaxLength(50, ErrorMessage = "Max Length should be 50 characters")]
        [MinLength(5, ErrorMessage = "Min Length should be 5 characters")]
        public string Name { get; init; }

        [Range(22, 60)]
        public int Age { get; init; }

        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; init; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; init; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; init; }

        [EmailAddress]
        public string? Email { get; init; }

        [Phone]
        public string? Phone { get; init; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; init; }
        public Gender Gender { get; init; }
        public EmployeeType EmployeeType { get; init; }
    }
}
