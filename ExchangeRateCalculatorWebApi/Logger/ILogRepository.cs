using ExchangeRateCalculatorWebApi.Models;

namespace ExchangeRateCalculatorWebApi.Logger
{
    public interface ILogRepository
    {
        void AddApiLog(CallToApiLog apiLog);
        void AddExternalLog(string data, string route);
        CallToApiLog[] GetApiLogs();
        CallToExternalResourceLog[] GetExternalLogs();
    }
}