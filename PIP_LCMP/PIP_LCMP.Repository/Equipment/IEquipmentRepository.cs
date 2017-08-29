using PIP_LCMP.BusinessEntities.Equipment;
using System.Collections.Generic;

namespace PIP_LCMP.Repositories.Equipment
{
    public interface IEquipmentRepository
    {
        ICollection<EquipmentModel> GetAllEquipments();

        EquipmentModel GetEquipmentById(int id);

        int AddEquipment(EquipmentModel equipment);

    }
}
