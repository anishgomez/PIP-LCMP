using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity GetOne(Expression<Func<TEntity, bool>> predicate);
    }
}
