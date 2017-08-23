using PIP_LCMP.BusinessEntities.Fleet;
using System.Collections.Generic;

namespace PIP_LCMP.Repositories.Fleet
{
    public interface IFleetRepository
    {
        ICollection<BusinessEntities.Fleet.FleetModel> GetAllFleet();
    }
}
