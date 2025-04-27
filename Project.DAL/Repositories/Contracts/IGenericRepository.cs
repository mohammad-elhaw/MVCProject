using Project.DAL.Entities.Shared;
using System.Linq.Expressions;

namespace Project.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool withTrack);
        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool withTrack);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Add(TEntity entity);
    }
}
