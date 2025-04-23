using Project.BLL.DTO.Employee;

namespace Project.BLL.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(string? SearchByName, bool withTrack = false);
        EmployeeDetailsDto? GetEmployeeById(int id, bool withTrack = false);
        int CreateEmployee(EmployeeForCreationDto employee);
        bool UpdateEmployee(int empId, EmployeeForUpdateDto employee);
        bool DeleteEmployee(int id);
    }
}
