using PIP_LCMP.BusinessEntities.FleetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Services.FleetModel
{
    public interface IFleetModelService
    {
        ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId);
    }
}
