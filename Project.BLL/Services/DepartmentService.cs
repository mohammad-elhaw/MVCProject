using Project.BLL.DTO.Department;
using Project.BLL.Factories;
using Project.BLL.Services.Contracts;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        public IEnumerable<DepartmentDto> GetAllDepartments(bool withTrack)
        {
            var departments = _departmentRepository.GetDepartments(withTrack);
            return departments.Select(d => d.ToDepartmentDto()); // extension method mapping
        }

        public DepartmentDetailsDto? GetDepartmentById(int id, bool withTrack)
        {
            var department = _departmentRepository.GetDepartment(id, withTrack);
            return department is null ? null : new DepartmentDetailsDto() // manual mapping
            {
                Id = id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn.GetValueOrDefault()),
                IsDeleted = department.IsDeleted,
                LastModifiedBy = department.LastModifiedBy,
            };
        }

        public int AddDepartment(DepartmentForCreationDto departmentDto) =>
            _departmentRepository.AddDepartment(departmentDto.ToDepartment());

        // Using this way to update to update only properties that changed
        public bool UpdateDepartment(int deptId, DepartmentForUpdateDto departmentDto, bool withTrack)
        {
            var department = _departmentRepository.GetDepartment(deptId, withTrack);
            if (department is null) return false;

            department.Code = departmentDto.Code;
            department.Name = departmentDto.Name;
            department.Description = departmentDto.Description;
            department.CreatedOn = departmentDto.DateOfCreation?.ToDateTime(new TimeOnly());
            int saved = _departmentRepository.Save();
            return saved > 0;
        }

        public bool DeleteDepartment(int deptId)
        {
            var department = _departmentRepository.GetDepartment(deptId, withTrack: false);
            if (department is null) return false;

            return _departmentRepository.DeleteDepartment(department) > 0;
        }

    }
}
