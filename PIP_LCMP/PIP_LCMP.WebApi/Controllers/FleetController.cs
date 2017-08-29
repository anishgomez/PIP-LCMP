using PIP_LCMP.Api.Filters;
using PIP_LCMP.BusinessEntities.Fleet;
using PIP_LCMP.Services.Fleet;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/fleet")]
    [AuthorizeUser]
    public class FleetController : ApiController
    {
        private IFleetService _fleetService;
        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }

        [HttpGet]
        [Route("getAllFleets")]
        public IHttpActionResult GetAllFleets()
        {
            var fleets = _fleetService.GetFleets();
            if (fleets != null)
                return Ok(fleets);
            return BadRequest(Constants.NoFleets);
        }

        [HttpGet]
        [Route("getFleet")]
        public IHttpActionResult GetFleetById(int id)
        {
            var fleet = _fleetService.GetFleetModelById(id);
            if (fleet != null)
                return Ok(fleet);
            return BadRequest(Constants.NoFleets);
        }

        [HttpPost]
        [Route("addFleet")]
        public IHttpActionResult AddFleet(FleetModel fleet)
        {
            var response = _fleetService.AddFleet(fleet);
            return Ok(response);
        }
    }
}
