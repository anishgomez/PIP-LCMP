using PIP_LCMP.BusinessEntities.Account;
using PIP_LCMP.Services.Account;
using PIP_LCMP.Utilities;
using System.Web.Http;

namespace PIP_LCMP.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequestModel loginModel)
        {

            var loginResult = _accountService.ValidateLogin(loginModel);
            if (loginResult != null)
                return Ok(loginResult);
            return BadRequest(Constants.InvalidLogin);

        }
    }
}
