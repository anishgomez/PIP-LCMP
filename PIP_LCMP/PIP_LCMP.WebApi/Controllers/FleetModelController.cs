using PIP_LCMP.Api.Filters;
using PIP_LCMP.BusinessEntities.FleetModel;
using PIP_LCMP.Services.FleetModel;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/fleetmodel")]
    [AuthorizeUser]
    public class FleetModelController : ApiController
    {
        private IFleetModelService _fleetModelService;
        public FleetModelController(IFleetModelService fleetModelService)
        {
            _fleetModelService = fleetModelService;
        }

        [HttpGet]
        [Route("getFleetModels")]
        public IHttpActionResult GetFleetModelsByFleetId(int fleetId)
        {
            var fleetModels = _fleetModelService.GetFleetModelsByFleetId(fleetId);
            if (fleetModels != null)
                return Ok(fleetModels);
            return BadRequest(Constants.NoFleetModels);
        }

        [HttpPost]
        [Route("addFleetModel")]
        public IHttpActionResult AddFleetModel(FleetModelModel fleetModelModel)
        {
            var response = _fleetModelService.AddFleetModel(fleetModelModel);
            return Ok(response);
        }
    }
}
