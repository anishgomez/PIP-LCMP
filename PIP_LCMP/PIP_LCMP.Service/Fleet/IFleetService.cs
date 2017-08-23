using PIP_LCMP.BusinessEntities.Fleet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Services.Fleet
{
    public interface IFleetService
    {
        ICollection<FleetModel> GetFleets();
    }
}
