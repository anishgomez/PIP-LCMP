using PIP_LCMP.Services.Account;
using PIP_LCMP.Services.Equipment;
using PIP_LCMP.Services.Fleet;
using PIP_LCMP.Services.FleetModel;
using SimpleInjector;

namespace PIP_LCMP.Api.DI
{
    public static class DependencyResolver
    {
        public static void RegisterControllerDependencies(this Container container)
        {
            container.Register<IAccountService, AccountService>(Lifestyle.Scoped);
            container.Register<IFleetService, FleetService>(Lifestyle.Scoped);
            container.Register<IFleetModelService, FleetModelService>(Lifestyle.Scoped);
            container.Register<IEquipmentService, EquipmentService>(Lifestyle.Scoped);
        }
    }
}