using PIP_LCMP.Services.Fleet;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/fleet")]
    public class FleetController : ApiController
    {
        private IFleetService _fleetService;
        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllFleets")]
        public IHttpActionResult GetAllFleets()
        {
            var fleets = _fleetService.GetFleets();
            if (fleets != null)
                return Ok(fleets);
            return BadRequest(Constants.NoFleets);
        }
    }
}
