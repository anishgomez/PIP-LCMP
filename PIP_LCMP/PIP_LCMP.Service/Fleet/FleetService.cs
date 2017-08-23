using System.Collections.Generic;
using PIP_LCMP.Repositories.Fleet;

namespace PIP_LCMP.Services.Fleet
{
    public class FleetService : IFleetService
    {
        private IFleetRepository _fleetRepository;
        public FleetService(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }
        public ICollection<BusinessEntities.Fleet.FleetModel> GetFleets()
        {
            return _fleetRepository.GetAllFleet();
        }
    }
}
