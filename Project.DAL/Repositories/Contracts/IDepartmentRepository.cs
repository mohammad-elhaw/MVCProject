using Project.DAL.Entities;

namespace Project.DAL.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        public void AddDepartment(Department department);
        public void RemoveDepartment(Department department);
        public Department GetDepartment(int id, bool withTrack = false);
        public IEnumerable<Department> GetDepartments(bool withTrack = false);
    }
}
