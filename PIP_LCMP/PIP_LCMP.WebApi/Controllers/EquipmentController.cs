using PIP_LCMP.Api.Filters;
using PIP_LCMP.BusinessEntities.Equipment;
using PIP_LCMP.Services.Equipment;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/equipment")]
    [AuthorizeUser]
    public class EquipmentController : ApiController
    {
        private IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Route("getAllEquipments")]
        public IHttpActionResult GetAllEquipments()
        {
            var equipments = _equipmentService.GetEquipments();
            if (equipments != null)
                return Ok(equipments);
            return BadRequest(Constants.NoEquipments);
        }

        [HttpGet]
        [Route("getEquipment")]
        public IHttpActionResult GetEquipmentById(int id)
        {
            var equipment = _equipmentService.GetEquipmentById(id);
            if (equipment != null)
                return Ok(equipment);
            return BadRequest(Constants.NoEquipments);
        }

        [HttpPost]
        [Route("addEquipment")]
        public IHttpActionResult AddEquipment(EquipmentModel equipmentModel)
        {
            var response = _equipmentService.AddEquipment(equipmentModel);
            return Ok(response);
        }
    }
}
