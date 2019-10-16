using ExchangeRateCalculatorWebApi.Models;

namespace ExchangeRateCalculatorWebApi.CurrencyCalculator
{
    public interface IApiManager
    {
        ExchangeRatesTable[] GetAvailableCurrencies();
        CurrencyJsonModel GetRates(string currency);
    }
}