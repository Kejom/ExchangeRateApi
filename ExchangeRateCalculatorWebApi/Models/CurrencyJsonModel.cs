using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateCalculatorWebApi.Models
{
    public class CurrencyJsonModel
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public RatesModel[] Rates { get; set; }
    }

    public class RatesModel
    {
        public string Mid { get; set; }
    }

    public class CurrencyResponseModel
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
    }
    public class ExchangeRatesTable
    {
        public List<AvailableCurrency> Rates { get; set; }
    }
    public class AvailableCurrency
    {
        public string Currency { get; set; }
        public string Code { get; set; }
    }
    public class AvailableCurrenciesResponse
    {
        public List<AvailableCurrency> AvailableCurrencies { get; set; }
        public string Intro { get; set; }
    }

}