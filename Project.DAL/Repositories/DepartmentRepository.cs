using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Entities;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    // Primary Constructor appear in .net 8 c#12
    public class DepartmentRepository(AppDbContext appDbContext) : GenericRepository<Department>(appDbContext), IDepartmentRepository
    {
        public void AddDepartment(Department department) => Add(department);

        public Department GetDepartment(int id, bool withTrack = false) =>
            GetByCondition(d => d.Id == id, withTrack).SingleOrDefault();

        public IEnumerable<Department> GetDepartments(bool withTrack = false) =>
            GetByCondition(d=>d.IsDeleted == false, withTrack).ToList();

        public void RemoveDepartment(Department department) => Delete(department);
    }
}
