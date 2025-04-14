using Project.DAL.Entities;
using Project.DAL.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool withTrack);
        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool withTrack);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Add(TEntity entity);
        int Save();
    }
}
