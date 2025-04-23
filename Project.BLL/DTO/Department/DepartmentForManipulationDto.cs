using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Department
{
    public abstract record DepartmentForManipulationDto
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; init; }
        [Required(ErrorMessage ="Code is Required")]
        public string Code { get; init; }
        public string? Description { get; init; }
        public DateOnly? DateOfCreation { get; init; }
    }
}

