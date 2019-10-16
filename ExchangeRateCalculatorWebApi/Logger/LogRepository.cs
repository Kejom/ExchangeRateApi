using ExchangeRateCalculatorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateCalculatorWebApi.Logger
{
    public class LogRepository : ILogRepository
    {
        private LogContext _context;

        public LogRepository()
        {
            _context = new LogContext();
        }

        public CallToApiLog[] GetApiLogs()
        {
            return _context.CallsToApi.ToArray();
        }
        public CallToExternalResourceLog[] GetExternalLogs()
        {
            return _context.CallsToExternalResources.ToArray();
        }



        public void AddApiLog(CallToApiLog apiLog)
        {
      
            _context.CallsToApi.Add(apiLog);
            _context.SaveChanges();
        }

        public void AddExternalLog(string data, string route)
        {
            var time = DateTime.Now.ToString();

            var log = new CallToExternalResourceLog
            {
                Id = 1,
                DataReceived = data,
                DateTime = time,
                RouteCalled = route
            };
            _context.CallsToExternalResources.Add(log);
            _context.SaveChanges();
        }



    }
}