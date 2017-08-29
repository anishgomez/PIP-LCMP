using PIP_LCMP.Repositories.ContextProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Linq.Expressions;
using PIP_LCMP.Repositories.UnitofWork;

namespace PIP_LCMP.Repositories.Fleet
{
    public class FleetRepository : BaseRepository<DataEntities.Fleet>, IFleetRepository
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public FleetRepository(IDbContextProvider dbContextProvider, IUnitOfWork unitOfWork)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.Fleet, BusinessEntities.Fleet.FleetModel>()
           );
            _mapper = config.CreateMapper();
            _unitOfWork = unitOfWork;
        }

        public ICollection<BusinessEntities.Fleet.FleetModel> GetAllFleet()
        {
            Expression<Func<DataEntities.Fleet, bool>> predicate = (it => it.IsActive);
            var fleets = GetAll(predicate).ToList();
            if (fleets.Count > 0)
                return _mapper.Map<List<DataEntities.Fleet>, List<BusinessEntities.Fleet.FleetModel>>(fleets);
            return null;
        }

        public BusinessEntities.Fleet.FleetModel GetFleetById(int id)
        {
            var fleet = GetById(id);
            if (fleet != null)
                return _mapper.Map<BusinessEntities.Fleet.FleetModel>(fleet);
            return null;
        }

        public int AddFleet(BusinessEntities.Fleet.FleetModel fleetModel)
        {
            var fleet = new DataEntities.Fleet
            {
                Name = fleetModel.Name,
                CreatedDate = DateTime.Now,
                Description = fleetModel.Description,
                IsActive = true,
            };
            Add(fleet);
            _unitOfWork.SaveChanges();
            return fleet.Id;
        }
    }
}
