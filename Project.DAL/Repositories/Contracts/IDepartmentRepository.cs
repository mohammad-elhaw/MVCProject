using Project.DAL.Entities;
using Project.DAL.Entities.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        public void AddDepartment(Department department);
        public void RemoveDepartment(Department department);
        public Department GetDepartment(int id, bool withTrack = false);
        public IEnumerable<Department> GetDepartments(bool withTrack = false);
        public int Save();
    }
}
