using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.Repositories.ContextProvider;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;
using PIP_LCMP.Repositories.UnitofWork;

namespace PIP_LCMP.Repositories.Equipment
{
    public class EquipmentRepository : BaseRepository<DataEntities.Equipment>, IEquipmentRepository
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public EquipmentRepository(IDbContextProvider dbContextProvider, IUnitOfWork unitOfWork)
            : base(dbContextProvider)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<DataEntities.Equipment, EquipmentModel>()
           );
            _mapper = config.CreateMapper();
            _unitOfWork = unitOfWork;
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

        public int AddEquipment(EquipmentModel equipmentModel, int userId)
        {
            var equipment = new DataEntities.Equipment
            {
                Name = equipmentModel.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = userId,
                IsActive = true,
                FleetModelId = equipmentModel.FleetModelId,
            };
            Add(equipment);
            _unitOfWork.SaveChanges();
            return equipment.Id;
        }

        public bool EditEquipment(EquipmentModel equipmentModel, int userId)
        {
            var equipment = new DataEntities.Equipment
            {
                Name = equipmentModel.Name,
                IsActive = true,
                FleetModelId = equipmentModel.FleetModelId,
                UpdatedDate = DateTime.Now,
                UpdatedBy = userId,
            };
            Edit(equipment);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteEquipment(int equipmentId, int userId)
        {
            var equipment = GetById(equipmentId);
            equipment.IsActive = false;
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
