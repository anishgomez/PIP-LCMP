using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.Fleet;
using PIP_LCMP.BusinessEntities.Generic;
using PIP_LCMP.Repositories.Fleet;
using PIP_LCMP.Utilities;

namespace PIP_LCMP.Services.Fleet
{
    public class FleetService : IFleetService
    {
        private IFleetRepository _fleetRepository;
        public FleetService(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public BusinessEntities.Fleet.FleetModel GetFleetModelById(int id)
        {
            return _fleetRepository.GetFleetById(id);
        }

        public ICollection<BusinessEntities.Fleet.FleetModel> GetFleets()
        {
            return _fleetRepository.GetAllFleet();
        }

        public GenericResponseModel AddFleet(BusinessEntities.Fleet.FleetModel fleetModel, int userId)
        {
            var fleetId = _fleetRepository.AddFleet(fleetModel, userId);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.AddFleetSuccess,
                Response = fleetId,
            };
        }
    }
}
