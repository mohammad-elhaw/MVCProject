using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Department
{
    public record DepartmentDetailsDto
    {
        public int Id { get; init; }
        public int CreatedBy { get; init; }
        public DateOnly? CreatedOn { get; init; }
        public int LastModifiedBy { get; init; }
        public bool IsDeleted { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
        public string? Description { get; init; }
    }
}
