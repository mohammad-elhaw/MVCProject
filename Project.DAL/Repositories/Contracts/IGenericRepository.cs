using Project.DAL.Entities;
using Project.DAL.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool withTrack);
        TEntity GetByID(int id, bool withTrack);
        void Update(TEntity entity);
        int Delete(TEntity entity);
        int Add(TEntity entity);
        int Save();
    }
}
