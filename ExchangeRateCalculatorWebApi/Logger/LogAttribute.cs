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

            var log = new CallToApiLog
            {
                DataSent = actionExecutedContext.Response.Content.ReadAsStringAsync().Result,
                DateTime = DateTime.Now.ToString(),
                ClientIp = HttpContext.Current.Request.UserHostAddress,
                RouteCalled = actionExecutedContext.Request.RequestUri.AbsolutePath
        };
            var logger = new LogRepository();
            logger.AddApiLog(log);

        }
    }
}