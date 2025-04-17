using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Project.DAL.Data;
using Project.DAL.Entities;
using Project.DAL.Entities.Shared;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public abstract class GenericRepository<TEntity>(AppDbContext _appDbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity entity) => _appDbContext.Set<TEntity>().Add(entity);
        public void Update(TEntity entity) => _appDbContext.Set<TEntity>().Update(entity);
        public void Delete(TEntity entity) => _appDbContext.Set<TEntity>().Remove(entity);

        public IEnumerable<TEntity> GetAll(bool withTrack) =>
            !withTrack?
                _appDbContext.Set<TEntity>().AsNoTracking() :
                _appDbContext.Set<TEntity>();

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool withTrack)
        {
            var localEntities = _appDbContext.Set<TEntity>()
                .Local.Where(expression.Compile())
                .ToList();

            if(localEntities.Any()) return localEntities;
            
            return !withTrack ?
                _appDbContext.Set<TEntity>().Where(expression).AsNoTracking() :
                _appDbContext.Set<TEntity>().Where(expression);

        }
        public int Save() => _appDbContext.SaveChanges();

    }
}
