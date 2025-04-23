using Project.BLL.DTO.Employee;
using Project.BLL.Factories;
using Project.BLL.Services.Contracts;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;

namespace Project.BLL.Services
{
    public class EmployeeService(IRepositoryManager repository) : IEmployeeService
    {
        public int CreateEmployee(EmployeeForCreationDto employee)
        {
            Employee employeeEntity = new Employee();
            employee.ToEmployee(employeeEntity);
            repository.Employee.AddEmployee(employeeEntity);
            return repository.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = repository.Employee.GetEmployee(id, withTrack: true);
            if (employee is null) return false;
            employee.IsDeleted = true;
            int result = repository.SaveChanges();
            return result > 0;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(string? SearchByName, bool withTrack = false)
        {
            var employees = repository.Employee.GetEmployees(SearchByName, withTrack);
            return employees.Select(e => e.ToEmployeeDto());
        }

        public EmployeeDetailsDto? GetEmployeeById(int id, bool withTrack = false)
        {
            var employee = repository.Employee.GetEmployee(id, withTrack);
            return employee is null ? null :employee.ToEmployeeDetailsDto();
        }

        public bool UpdateEmployee(int empId, EmployeeForUpdateDto employeeDto)
        {
            var employeeEntity = repository.Employee.GetEmployee(empId, withTrack: true);
            if (employeeEntity is null) return false;
            
            employeeDto.ToEmployee(employeeEntity);
            int result = repository.SaveChanges();
            return result > 0;
        }
    }
}
