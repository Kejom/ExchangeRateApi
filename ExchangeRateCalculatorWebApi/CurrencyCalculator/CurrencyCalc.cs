
using ExchangeRateCalculatorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRateCalculatorWebApi.CurrencyCalculator
{
    public class CurrencyCalc
    {
        private IApiManager _connector;
        private List<AvailableCurrency> _availableCurrencies;

        public CurrencyCalc(IApiManager connector)
        {
            _connector = connector;
            _availableCurrencies = _connector.GetAvailableCurrencies()[0].Rates;
            _availableCurrencies.Add(new AvailableCurrency { Code = "PLN", Currency = "Polish Zloty" });

        }
        public AvailableCurrenciesResponse GetAvailableCurrencies()
        {
            var response = new AvailableCurrenciesResponse
            {
                Intro = "List of available currencies," +
               " use: /calculate/'amount'/'its currency code'/'currency code you want to calculate' path to use the API",
                AvailableCurrencies = _availableCurrencies
            };
            return response;
        }

        private string[] GetCurrencyCodes()
        {
            var codes = new List<string>();

            foreach (var code in _availableCurrencies)
            {
                codes.Add(code.Code);
            }
            return codes.ToArray();
        }

        public double CalculateCurrency(int amount, string cur1, string cur2)
        {
            cur1 = cur1.ToUpper();
            cur2 = cur2.ToUpper();
            var availableCurrencies = this.GetCurrencyCodes();
            var calculatedCurrency = (double)amount;
            if (!availableCurrencies.Contains(cur1) || !availableCurrencies.Contains(cur2))
            {
                throw new ArgumentOutOfRangeException("not supported currency given, you can check supported currencies under app main url directory");
            }
            if (cur1 == cur2)
            {
                return calculatedCurrency;
            }

            if (cur1 != "PLN")
            {
                var rate = double.Parse(_connector.GetRates(cur1).Rates[0].Mid);
                calculatedCurrency *= rate;
            }
            if (cur2 != "PLN")
            {
                var rate = double.Parse(_connector.GetRates(cur2).Rates[0].Mid);
                calculatedCurrency /= rate;
            }


            return Math.Round(calculatedCurrency, 2);

        }
    }
}