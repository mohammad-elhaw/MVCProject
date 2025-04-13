using Project.DAL.Entities.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }
}
