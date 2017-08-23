using PIP_LCMP.Utilities.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PIP_LCMP.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private ILogManager _logManager;
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            _logManager = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogManager)) as ILogManager;
            var exception = actionExecutedContext.Exception;
            var errorMessage = exception.Message;
            _logManager.LogError(errorMessage, exception);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error. Please try later");
        }
    }
}