using ExchangeRateCalculatorWebApi.Logger;
using ExchangeRateCalculatorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ExchangeRateCalculatorWebApi.Controllers
{
    public class LogsController : ApiController
    {
        private ILogRepository _logcontext;

        public LogsController()
        {
            _logcontext = new LogRepository();
        }

        [LogApiRequest]
        [Route("logs/api")]
        [HttpGet]
        public IHttpActionResult GetApiLogs()
        {

            
            return Ok(_logcontext.GetApiLogs());
        }
        [LogApiRequest]
        [Route("logs/ext")]
        [HttpGet]
        public IHttpActionResult GetExtLogs()
        {
            return Ok(_logcontext.GetExternalLogs());
        }


    }
}
