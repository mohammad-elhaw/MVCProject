using Project.DAL.Data;
using Project.DAL.Repositories.Contracts;

namespace Project.DAL.Repositories
{
    public class RepositoryManager(
        AppDbContext context,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository) : IRepositoryManager
    {
        public IEmployeeRepository Employee => employeeRepository;

        public IDepartmentRepository Department => departmentRepository;

        public int SaveChanges() => context.SaveChanges();
    }
}
