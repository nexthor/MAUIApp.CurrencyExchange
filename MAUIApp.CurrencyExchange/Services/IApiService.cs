using MAUIApp.CurrencyExchange.Models;

namespace MAUIApp.CurrencyExchange.Services
{
    public interface IApiService
    {
        Task<Root> ConvertCurrency(string to, string from, int amount, CancellationToken cancellationToken = default);
    }
}