using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.FleetModel;
using PIP_LCMP.Repositories.ContextProvider;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;

namespace PIP_LCMP.Repositories.FleetModel
{
    public class FleetModelRepository : BaseRepository<DataEntities.FleetModel>, IFleetModelRepository
    {
        private IMapper _mapper;
        public FleetModelRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.FleetModel, FleetModelModel>()
           );
            _mapper = config.CreateMapper();
        }

        public ICollection<FleetModelModel> GetFleetModelsByFleetId(int fleetId)
        {
            Expression<Func<DataEntities.FleetModel, bool>> predicate = (it => it.IsActive && it.FleetId == fleetId);
            var fleetModels = GetAll(predicate).ToList();
            if (fleetModels.Count > 0)
                return _mapper.Map<List<DataEntities.FleetModel>, List<FleetModelModel>>(fleetModels);
            return null;
        }
    }
}
