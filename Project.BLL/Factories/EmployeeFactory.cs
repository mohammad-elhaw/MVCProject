using Project.BLL.DTO.Employee;
using Project.DAL.Entities.EmployeeEntity;

namespace Project.BLL.Factories
{
    public static class EmployeeFactory
    {
        public static void ToEmployee(this EmployeeForManipulationDto employeeDto, Employee employeeReturn)
        {
            employeeReturn.Name = employeeDto.Name;
            employeeReturn.Age = employeeDto.Age;
            employeeReturn.Address = employeeDto.Address;
            employeeReturn.Salary = employeeDto.Salary;
            employeeReturn.IsActive = employeeDto.IsActive;
            employeeReturn.Email = employeeDto.Email;
            employeeReturn.PhoneNumber = employeeDto.Phone;
            employeeReturn.HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly());
            employeeReturn.Gender = employeeDto.Gender;
            employeeReturn.EmployeeType = employeeDto.EmployeeType;
            employeeReturn.DepartmentId = employeeDto.DepartmentId;
        }

        public static EmployeeDto ToEmployeeDto(this Employee employee) =>
            new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Gender = employee.Gender.ToString(),
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                EmployeeType = employee.EmployeeType.ToString(),
                Department = employee.Department?.Name
            };

        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employee) =>
            new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Gender = employee.Gender.ToString(),
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                EmployeeType = employee.EmployeeType.ToString(),
                CreatedBy = employee.CreatedBy,
                LastModifiedBy = employee.LastModifiedBy,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                CreatedOn = employee.CreatedOn,
                LastModifiedOn = employee.LastModifiedOn,
                DepartmentId = employee.DepartmentId
            };
    }
}
