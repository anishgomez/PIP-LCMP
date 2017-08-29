using System;
using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.BusinessEntities.Generic;
using PIP_LCMP.Repositories.Equipment;
using PIP_LCMP.Utilities;

namespace PIP_LCMP.Services.Equipment
{
    public class EquipmentService : IEquipmentService
    {
        private IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public ICollection<EquipmentModel> GetEquipments()
        {
            return _equipmentRepository.GetAllEquipments();
        }

        public EquipmentModel GetEquipmentById(int id)
        {
            return _equipmentRepository.GetEquipmentById(id);
        }

        public GenericResponseModel AddEquipment(EquipmentModel equipmentModel)
        {
            var equipmentId = _equipmentRepository.AddEquipment(equipmentModel);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.AddEquipmentSuccess,
                Response = equipmentId,
            };
        }
    }
}
