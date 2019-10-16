using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateCalculatorWebApi.Models
{
    public class CallToApiLog
    {
        public int Id { get; set; }
        public string ClientIp { get; set; }
        public string RouteCalled { get; set; }
        public string DateTime { get; set; }
        public string DataSent { get; set; }
    }
    public class CallToExternalResourceLog
    {
        public int Id { get; set; }
        public string RouteCalled { get; set; }
        public string DateTime { get; set; }
        public string DataReceived { get; set; }
    }
}