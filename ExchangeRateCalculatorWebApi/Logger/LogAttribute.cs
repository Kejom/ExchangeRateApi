using ExchangeRateCalculatorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace ExchangeRateCalculatorWebApi.Logger
{
    public class LogApiRequestAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;
            var actionContext = actionExecutedContext.ActionContext;


            var log = new CallToApiLog
            {
                DataSent = response.Content.ReadAsStringAsync().Result,
                DateTime = DateTime.Now.ToString(),
                ClientIp = HttpContext.Current.Request.UserHostAddress,
                RouteCalled = request.RequestUri.AbsolutePath
        };
            var logger = new LogRepository();
            logger.AddApiLog(log);

        }
    }
}