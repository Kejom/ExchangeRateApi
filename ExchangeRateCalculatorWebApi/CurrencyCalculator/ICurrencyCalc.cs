using ExchangeRateCalculatorWebApi.Models;

namespace ExchangeRateCalculatorWebApi.CurrencyCalculator
{
    public interface ICurrencyCalc
    {
        double CalculateCurrency(int amount, string cur1, string cur2);
        AvailableCurrenciesResponse GetAvailableCurrencies();
    }
}