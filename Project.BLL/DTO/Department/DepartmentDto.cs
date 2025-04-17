using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Department
{
    public record DepartmentDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
        public string? Description { get; init; }
        [Display(Name = "Date Of Creation")]
        public DateOnly? DataOfCreation { get; init; }
    }
}
