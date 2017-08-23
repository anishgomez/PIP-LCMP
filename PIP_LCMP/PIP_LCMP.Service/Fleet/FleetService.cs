using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIP_LCMP.BusinessEntities.Fleet;
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
        public ICollection<FleetModel> GetFleets()
        {
            return _fleetRepository.GetAllFleet();
        }
    }
}
