using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Entities;
using Project.DAL.Entities.Shared;
using Project.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext _appDbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public int Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
            return _appDbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            return _appDbContext.SaveChanges();
        }

        public TEntity GetByID(int id, bool withTrack) =>
            _appDbContext.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool withTrack)
        {
            if (withTrack)
                return _appDbContext.Set<TEntity>().ToList();

            return _appDbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            _appDbContext.SaveChanges();
        }

        public int Save() => _appDbContext.SaveChanges();
    }
}
