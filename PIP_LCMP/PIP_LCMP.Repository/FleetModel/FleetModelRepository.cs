using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.FleetModel;
using PIP_LCMP.Repositories.ContextProvider;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;
using PIP_LCMP.Repositories.UnitofWork;

namespace PIP_LCMP.Repositories.FleetModel
{
    public class FleetModelRepository : BaseRepository<DataEntities.FleetModel>, IFleetModelRepository
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public FleetModelRepository(IDbContextProvider dbContextProvider, IUnitOfWork unitOfWork)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.FleetModel, FleetModelModel>()
           );
            _mapper = config.CreateMapper();
            _unitOfWork = unitOfWork;
        }

        public ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId)
        {
            Expression<Func<DataEntities.FleetModel, bool>> predicate = (it => it.IsActive && it.FleetId == fleetId);
            var fleetModels = GetAll(predicate).ToList();
            if (fleetModels.Count > 0)
                return _mapper.Map<List<DataEntities.FleetModel>, List<FleetModelModel>>(fleetModels);
            return null;
        }

        public FleetModelModel GetFleetModelById(int id)
        {
            var fleetModel = GetById(id);
            if (fleetModel != null)
                return _mapper.Map<FleetModelModel>(fleetModel);
            return null;
        }

        public int AddFleetModel(FleetModelModel fleetModelModel)
        {
            var fleetModel = new DataEntities.FleetModel
            {
                Name = fleetModelModel.Name,
                IsActive = true,
                CreatedAt = DateTime.Now,
                FleetId = fleetModelModel.FleetId,
                SMUHours = fleetModelModel.SMUHours,
            };
            Add(fleetModel);
            _unitOfWork.SaveChanges();
            return fleetModel.Id;
        }
    }
}
