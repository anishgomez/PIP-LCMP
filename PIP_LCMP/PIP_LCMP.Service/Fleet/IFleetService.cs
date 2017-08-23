using System.Collections.Generic;

namespace PIP_LCMP.Services.Fleet
{
    public interface IFleetService
    {
        ICollection<BusinessEntities.Fleet.FleetModel> GetFleets();
    }
}
