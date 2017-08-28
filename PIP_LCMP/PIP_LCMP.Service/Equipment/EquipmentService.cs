using System.Collections.Generic;
using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.Repositories.Equipment;

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
    }
}
