using PIP_LCMP.Repositories.ContextProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Linq.Expressions;
using PIP_LCMP.BusinessEntities.Fleet;

namespace PIP_LCMP.Repositories.Fleet
{
    public class FleetRepository : BaseRepository<DataEntities.Fleet>, IFleetRepository
    {
        private IMapper _mapper;
        public FleetRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.Fleet, BusinessEntities.Fleet.FleetModel>()
           );
            _mapper = config.CreateMapper();
        }

        public ICollection<BusinessEntities.Fleet.FleetModel> GetAllFleet()
        {
            Expression<Func<DataEntities.Fleet, bool>> predicate = (it => it.IsActive);
            var fleets = GetAll(predicate).ToList();
            if (fleets.Count > 0)
                return _mapper.Map<List<DataEntities.Fleet>, List<BusinessEntities.Fleet.FleetModel>>(fleets);
            return null;
        }
    }
}
