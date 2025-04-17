using Project.BLL.DTO.Employee;
using Project.BLL.Factories;
using Project.BLL.Services.Contracts;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public int CreateEmployee(EmployeeForCreationDto employee)
        {
            Employee employeeEntity = new Employee();
            employee.ToEmployee(employeeEntity);
            _employeeRepository.AddEmployee(employeeEntity);
            return _employeeRepository.Save();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id, withTrack: true);
            if (employee is null) return false;
            employee.IsDeleted = true;
            int result = _employeeRepository.Save();
            return result > 0;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTrack = false)
        {
            var employees = _employeeRepository.GetEmployees(withTrack);
            return employees.Select(e => e.ToEmployeeDto());
        }

        public EmployeeDetailsDto? GetEmployeeById(int id, bool withTrack = false)
        {
            var employee = _employeeRepository.GetEmployee(id, withTrack);
            return employee is null ? null :employee.ToEmployeeDetailsDto();
        }

        public bool UpdateEmployee(int empId, EmployeeForUpdateDto employeeDto)
        {
            var employeeEntity = _employeeRepository.GetEmployee(empId, withTrack: true);
            if (employeeEntity is null) return false;
            
            employeeDto.ToEmployee(employeeEntity);
            int result = _employeeRepository.Save();
            return result > 0;
        }
    }
}
