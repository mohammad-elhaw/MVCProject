using Microsoft.EntityFrameworkCore;
using Project.DAL.Data.Repositories.Contracts;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data.Repositories
{
    // Primary Constructor appear in .net 8 c#12
    public class DepartmentRepository(AppDbContext appDbContext) : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public int AddDepartment(Department entity)
        {
            _appDbContext.Departments.Add(entity);
            return _appDbContext.SaveChanges();
        }

        public int DeleteDepartment(Department entity)
        {
            _appDbContext.Departments.Remove(entity);
            return _appDbContext.SaveChanges();
        }

        public Department GetDepartment(int id, bool withTrack) =>
            _appDbContext.Departments.Find(id);

        public IEnumerable<Department> GetDepartments(bool withTrack)
        {
            if (withTrack)
                return _appDbContext.Departments.ToList();

            return _appDbContext.Departments.AsNoTracking().ToList();
        }

        public void UpdateDepartment(Department entity)
        {
            _appDbContext.Departments.Update(entity);
            _appDbContext.SaveChanges();
        }

        public int Save() => _appDbContext.SaveChanges();
    }
}
