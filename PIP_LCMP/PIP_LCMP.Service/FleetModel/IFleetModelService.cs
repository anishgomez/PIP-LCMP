using PIP_LCMP.BusinessEntities.FleetModel;
using PIP_LCMP.BusinessEntities.Generic;
using System.Collections.Generic;

namespace PIP_LCMP.Services.FleetModel
{
    public interface IFleetModelService
    {
        ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId);

        FleetModelModel GetFleetModelById(int id);

        GenericResponseModel AddFleetModel(FleetModelModel fleetModelModel);
    }
}
