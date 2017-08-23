using PIP_LCMP.Repositories.ContextProvider;
using System;
using System.Data.Entity;

namespace PIP_LCMP.Repositories.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public UnitOfWork(IDbContextProvider dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
