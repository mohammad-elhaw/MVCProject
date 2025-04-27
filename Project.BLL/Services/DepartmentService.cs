using Project.BLL.DTO.Department;
using Project.BLL.Factories;
using Project.BLL.Services.Contracts;
using Project.DAL.Repositories.Contracts;

namespace Project.BLL.Services
{
    public class DepartmentService(IRepositoryManager repository) : IDepartmentService
    {

        public IEnumerable<DepartmentDto> GetAllDepartments(bool withTrack)
        {
            var departments = repository.Department.GetDepartments(withTrack);
            return departments.Select(d => d.ToDepartmentDto()); // extension method mapping
        }

        public DepartmentDetailsDto? GetDepartmentById(int id, bool withTrack)
        {
            var department = repository.Department.GetDepartment(id, withTrack);
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

        public int AddDepartment(DepartmentForCreationDto departmentDto)
        {
            repository.Department.AddDepartment(departmentDto.ToDepartment());
            return repository.SaveChanges();
        }

        // Using this way to update to update only properties that changed
        public bool UpdateDepartment(int deptId, DepartmentForUpdateDto departmentDto, bool withTrack)
        {
            var department = repository.Department.GetDepartment(deptId, withTrack);
            if (department is null) return false;

            department.Code = departmentDto.Code;
            department.Name = departmentDto.Name;
            department.Description = departmentDto.Description;
            department.CreatedOn = departmentDto.DateOfCreation?.ToDateTime(new TimeOnly());
            int saved = repository.SaveChanges();
            return saved > 0;
        }

        public bool DeleteDepartment(int deptId)
        {
            var department = repository.Department.GetDepartment(deptId, withTrack: true);
            if (department is null) return false;
            department.IsDeleted = true;
            int result = repository.SaveChanges();
            return result > 0;
        }

    }
}
