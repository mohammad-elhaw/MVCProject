using Project.DAL.Data;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class EmployeeRepository(AppDbContext appDbContext) : GenericRepository<Employee>(appDbContext), IEmployeeRepository
    {
        public void AddEmployee(Employee employee) => Add(employee);

        public Employee GetEmployee(int id, bool withTrack = false) =>
            GetByCondition(e => e.Id == id, withTrack).SingleOrDefault();

        public IEnumerable<Employee> GetEmployees(bool withTrack = false) =>
            GetByCondition(e=>e.IsDeleted == false ,withTrack).ToList();

        public void RemoveEmployee(Employee employee) => Delete(employee);
    }
}
