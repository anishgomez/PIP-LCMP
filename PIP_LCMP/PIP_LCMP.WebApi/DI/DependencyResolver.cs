using PIP_LCMP.Services.Account;
using SimpleInjector;

namespace PIP_LCMP.Api.DI
{
    public static class DependencyResolver
    {
        public static void RegisterControllerDependencies(this Container container)
        {
            container.Register<IAccountService, AccountService>(Lifestyle.Scoped);
        }
    }
}