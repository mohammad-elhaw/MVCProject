using Project.DAL.Entities.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(Employee employee);
        public Employee GetEmployee(int id, bool withTrack = false);
        public IEnumerable<Employee> GetEmployees(bool withTrack = false);
        public int Save();
    }
}
