using Project.DAL.Data;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class EmployeeRepository(AppDbContext appDbContext) :GenericRepository<Employee>(appDbContext), IEmployeeRepository
    {

    }
}
