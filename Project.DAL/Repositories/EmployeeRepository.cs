using Project.DAL.Data;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;

namespace Project.DAL.Repositories
{
    public class EmployeeRepository(AppDbContext appDbContext) : GenericRepository<Employee>(appDbContext), IEmployeeRepository
    {
        public void AddEmployee(Employee employee) => Add(employee);

        public Employee GetEmployee(int id, bool withTrack = false) =>
            GetByCondition(e => e.Id == id, withTrack).SingleOrDefault();

        public IEnumerable<Employee> GetEmployees(string? SearchByName, bool withTrack = false) =>
            GetByCondition(e =>
                (e.IsDeleted == false)  && 
                (string.IsNullOrWhiteSpace(SearchByName) || e.Name.ToLower().Contains(SearchByName.ToLower())), withTrack).ToList();

        public void RemoveEmployee(Employee employee) => Delete(employee);
    }
}
