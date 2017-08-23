using PIP_LCMP.Repositories.ContextProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PIP_LCMP.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        public BaseRepository(IDbContextProvider dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
    }
}
