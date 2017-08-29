using System.Collections.Generic;

namespace PIP_LCMP.Repositories.Fleet
{
    public interface IFleetRepository
    {
        ICollection<BusinessEntities.Fleet.FleetModel> GetAllFleet();

        BusinessEntities.Fleet.FleetModel GetFleetById(int id);

        int AddFleet(BusinessEntities.Fleet.FleetModel fleetModel);
    }
}
