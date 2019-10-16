using ExchangeRateCalculatorWebApi.Logger;
using ExchangeRateCalculatorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ExchangeRateCalculatorWebApi.CurrencyCalculator
{
    public class NBPApiManager : IApiManager
    {

        private ILogRepository _logger;

        public NBPApiManager(ILogRepository logger)
        {
            _logger = logger;
        }

        public CurrencyJsonModel GetRates(string currency)
        {
            var url = "http://api.nbp.pl/api/exchangerates/rates/a/" + currency;
            var client = new WebClient();
            var response = client.DownloadString(url);
            _logger.AddExternalLog(response, url);
            var calculatedCurrency = new JavaScriptSerializer().Deserialize<CurrencyJsonModel>(response);

            return calculatedCurrency;
        }
        public ExchangeRatesTable[] GetAvailableCurrencies()
        {
            var url = "http://api.nbp.pl/api/exchangerates/tables/a/";
            var client = new WebClient();
            var response = client.DownloadString(url);
            _logger.AddExternalLog(response, url);
            var table = new JavaScriptSerializer().Deserialize<ExchangeRatesTable[]>(response);
            
            return table;

        }
    }
}