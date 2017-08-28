using PIP_LCMP.BusinessEntities.Equipment;
using System.Collections.Generic;

namespace PIP_LCMP.Services.Equipment
{
    public interface IEquipmentService
    {
        ICollection<EquipmentModel> GetEquipments();

        EquipmentModel GetEquipmentById();
    }
}
