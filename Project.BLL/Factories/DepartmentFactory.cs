using Project.BLL.DTO.Department;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department) =>
            new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DataOfCreation = DateOnly.FromDateTime(department.CreatedOn.GetValueOrDefault())
            };

        public static Department ToDepartment(this DepartmentForManipulationDto departmentDto) =>
            new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation?.ToDateTime(new TimeOnly())
            };

    }
}
