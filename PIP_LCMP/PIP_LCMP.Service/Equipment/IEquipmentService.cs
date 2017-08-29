using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.BusinessEntities.Generic;
using System.Collections.Generic;

namespace PIP_LCMP.Services.Equipment
{
    public interface IEquipmentService
    {
        ICollection<EquipmentModel> GetEquipments();

        EquipmentModel GetEquipmentById(int id);

        GenericResponseModel AddEquipment(EquipmentModel equipmentModel);
    }
}
