using Project.DAL.Entities.EmployeeEntity;

namespace Project.DAL.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(Employee employee);
        public Employee GetEmployee(int id, bool withTrack = false);
        public IEnumerable<Employee> GetEmployees(string? searchByName, bool withTrack = false);
        public int Save();
    }
}
