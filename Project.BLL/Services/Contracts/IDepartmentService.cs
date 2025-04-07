using Project.BLL.DTO.Department;

namespace Project.BLL.Services.Contracts
{
    public interface IDepartmentService
    {
        int AddDepartment(DepartmentForCreationDto departmentDto);
        bool DeleteDepartment(int deptId);
        IEnumerable<DepartmentDto> GetAllDepartments(bool withTrack);
        DepartmentDetailsDto? GetDepartmentById(int id, bool withTrack);
        bool UpdateDepartment(int deptId, DepartmentForUpdateDto departmentDto, bool withTrack);
    }
}