using Project.BLL.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTrack = false);
        EmployeeDetailsDto? GetEmployeeById(int id, bool withTrack = false);
        int CreateEmployee(EmployeeForCreationDto employee);
        bool UpdateEmployee(int empId, EmployeeForUpdateDto employee);
        bool DeleteEmployee(int id);
    }
}
