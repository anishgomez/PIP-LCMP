using PIP_LCMP.BusinessEntities.Generic;
using System.Collections.Generic;

namespace PIP_LCMP.Services.Fleet
{
    public interface IFleetService
    {
        ICollection<BusinessEntities.Fleet.FleetModel> GetFleets();

        BusinessEntities.Fleet.FleetModel GetFleetModelById(int id);

        GenericResponseModel AddFleet(BusinessEntities.Fleet.FleetModel fleetModel);
    }
}
