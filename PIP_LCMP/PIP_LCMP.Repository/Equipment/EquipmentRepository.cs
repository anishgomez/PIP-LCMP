using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.Repositories.ContextProvider;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;

namespace PIP_LCMP.Repositories.Equipment
{
    public class EquipmentRepository : BaseRepository<DataEntities.Equipment>, IEquipmentRepository
    {
        private IMapper _mapper;
        public EquipmentRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.Equipment, EquipmentModel>()
           );
            _mapper = config.CreateMapper();
        }

        public ICollection<EquipmentModel> GetAllEquipments()
        {
            Expression<Func<DataEntities.Equipment, bool>> predicate = (it => it.IsActive);
            var equipments = GetAll(predicate).ToList();
            if (equipments.Count > 0)
                return _mapper.Map<List<DataEntities.Equipment>, List<EquipmentModel>>(equipments);
            return null;
        }

        public EquipmentModel GetEquipmentById(int id)
        {
            var equipment = GetById(id);
            if (equipment != null)
                return _mapper.Map<EquipmentModel>(equipment);
            return null;
        }
    }
}
