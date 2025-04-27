namespace Project.DAL.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        public IEmployeeRepository Employee { get; }
        public IDepartmentRepository Department { get; }

        public int SaveChanges();
    }
}
