using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments(bool withTrack);
        Department GetDepartment(int id);
        void UpdateDepartment(Department entity);
        void DeleteDepartment(Department entity);
        void AddDepartment(Department entity);
    }
}
