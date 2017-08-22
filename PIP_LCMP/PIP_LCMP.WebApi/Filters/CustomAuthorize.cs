using PIP_LCMP.Authorization.TokenManager;
using PIP_LCMP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PIP_LCMP.Api.Filters
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private ITokenManager _tokenManager;
        public CustomAuthorize()
        {

        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                    return false;
                _tokenManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ITokenManager)) as ITokenManager;
                var token = actionContext.Request.Headers.Authorization.Parameter;
                var isValid = _tokenManager.ValidateToken(token);
                if (isValid)
                {
                    var userId = _tokenManager.GetUserIdFromToken(token);
                    actionContext.Request.Properties.Add("UserId", userId);
                }
                return isValid;
            }
            catch
            {
                throw;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, Constants.UnauthorizedMessage);
        }
    }
}