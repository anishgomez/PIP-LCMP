using PIP_LCMP.DataEntities;
using PIP_LCMP.Repositories.ContextProvider;
using PIP_LCMP.Repositories.UnitofWork;
using SimpleInjector;

namespace PIP_LCMP.Repositories.DI
{
    public static class DependencyResolver
    {
        public static void RegisterRepositoryDependencies(this Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDbContextProvider, DbContextProvider>(Lifestyle.Scoped);
            container.Register<LCMPEntities>(Lifestyle.Scoped);
        }
    }
}
