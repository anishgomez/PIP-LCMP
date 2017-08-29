using PIP_LCMP.BusinessEntities.FleetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Repositories.FleetModel
{
    public interface IFleetModelRepository
    {
        ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId);
        FleetModelModel GetFleetModelById(int id);

        int AddFleetModel(FleetModelModel fleetModelModel);
    }
}
