using PIP_LCMP.Repositories.FleetModel;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.FleetModel;

namespace PIP_LCMP.Services.FleetModel
{
    public class FleetModelService : IFleetModelService
    {
        private IFleetModelRepository _fleetModelRepository;
        public FleetModelService(IFleetModelRepository fleetModelRepository)
        {
            _fleetModelRepository = fleetModelRepository;
        }

        public ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId)
        {
            return _fleetModelRepository.GetFleetModelsByFleetId(fleetId);
        }
    }
}
