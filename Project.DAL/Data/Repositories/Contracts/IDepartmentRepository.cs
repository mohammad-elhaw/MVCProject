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
        Department GetDepartment(int id, bool withTrack);
        void UpdateDepartment(Department entity);
        int DeleteDepartment(Department entity);
        int AddDepartment(Department entity);
        int Save();
    }
}
