using PIP_LCMP.DataEntities;
using SimpleInjector;
using System.Data.Entity;

namespace PIP_LCMP.Repositories.ContextProvider
{
    public class DbContextProvider : IDbContextProvider
    {
        private readonly Container _container;
        public DbContextProvider(Container container)
        {
            _container = container;
        }
        public DbContext GetDbContext()
        {
            return _container.GetInstance<LCMPEntities>();
        }
    }
}
