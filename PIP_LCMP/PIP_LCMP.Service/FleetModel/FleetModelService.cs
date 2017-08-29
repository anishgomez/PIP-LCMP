using PIP_LCMP.Repositories.FleetModel;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.FleetModel;
using System;
using PIP_LCMP.BusinessEntities.Generic;
using PIP_LCMP.Utilities;

namespace PIP_LCMP.Services.FleetModel
{
    public class FleetModelService : IFleetModelService
    {
        private IFleetModelRepository _fleetModelRepository;
        public FleetModelService(IFleetModelRepository fleetModelRepository)
        {
            _fleetModelRepository = fleetModelRepository;
        }

        public FleetModelModel GetFleetModelById(int id)
        {
            return _fleetModelRepository.GetFleetModelById(id);
        }

        public ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId)
        {
            return _fleetModelRepository.GetFleetModelsByFleetId(fleetId);
        }
        public GenericResponseModel AddFleetModel(FleetModelModel fleetModelModel)
        {
            var fleetModelId = _fleetModelRepository.AddFleetModel(fleetModelModel);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.AddFleetModelSuccess,
                Response = fleetModelId,
            };
        }

    }
}
