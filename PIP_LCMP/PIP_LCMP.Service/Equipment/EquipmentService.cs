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

        public GenericResponseModel AddEquipment(EquipmentModel equipmentModel, int userId)
        {
            var equipmentId = _equipmentRepository.AddEquipment(equipmentModel, userId);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.AddEquipmentSuccess,
                Response = equipmentId,
            };
        }

        public GenericResponseModel EditEquipment(EquipmentModel equipmentModel, int userId)
        {
            var isSuccess = _equipmentRepository.EditEquipment(equipmentModel, userId);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.EditEquipmentSuccess,
                Response = isSuccess,
            };
        }

        public GenericResponseModel DeleteEquipment(int equipmentId, int userId)
        {
            var isSuccess = _equipmentRepository.DeleteEquipment(equipmentId, userId);
            return new GenericResponseModel
            {
                IsSuccess = true,
                ResponseMessage = Constants.DeleteEquipmentSuccess,
                Response = isSuccess,
            };
        }
    }
}
