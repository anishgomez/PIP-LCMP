using PIP_LCMP.BusinessEntities.Equipment;
using System.Collections.Generic;

namespace PIP_LCMP.Repositories.Equipment
{
    public interface IEquipmentRepository
    {
        ICollection<EquipmentModel> GetAllEquipments();

        EquipmentModel GetEquipmentById(int id);

        int AddEquipment(EquipmentModel equipment, int userId);

        bool EditEquipment(EquipmentModel equipment, int userId);

        bool DeleteEquipment(int equipmentId, int userId);

    }
}
