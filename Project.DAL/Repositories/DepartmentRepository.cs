using Project.DAL.Data;
using Project.DAL.Entities;
using Project.DAL.Repositories.Contracts;

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
