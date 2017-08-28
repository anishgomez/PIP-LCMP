using PIP_LCMP.Api.Filters;
using PIP_LCMP.Services.Equipment;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/equipment")]
    public class EquipmentController : ApiController
    {
        private IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [AuthorizeUser]
        [HttpGet]
        [Route("getAllEquipments")]
        public IHttpActionResult GetAllEquipments()
        {
            var equipments = _equipmentService.GetEquipments();
            if (equipments != null)
                return Ok(equipments);
            return BadRequest(Constants.NoEquipments);
        }
    }
}
