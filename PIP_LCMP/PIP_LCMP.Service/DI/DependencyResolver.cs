using PIP_LCMP.Authorization.TokenManager;
using PIP_LCMP.Repositories.User;
using PIP_LCMP.Utilities.PasswordManager;
using SimpleInjector;

namespace PIP_LCMP.Services.DI
{
    public static class DependencyResolver
    {
        public static void RegisterBusinessServiceDependencies(this Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IPasswordManager, PasswordManager>(Lifestyle.Scoped);
            container.Register<ITokenManager, TokenManager>(Lifestyle.Scoped);
        }
    }
}
