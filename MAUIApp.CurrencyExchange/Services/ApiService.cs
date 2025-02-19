using MAUIApp.CurrencyExchange.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MAUIApp.CurrencyExchange.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public ApiService(IHttpClientFactory httpClient, IConfiguration config)
        {
            _httpClient = httpClient.CreateClient();
            _apiSettings = config.GetSection(nameof(ApiSettings)).Get<ApiSettings>() ?? throw new Exception("settings cannot be null");
        }

        public async Task<Root> ConvertCurrency(string to, string from, int amount)
        {
            try
            {
                string url = $"{_apiSettings.BaseUrl}?to={to}&from={from}&amount={amount}";
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("apikey", _apiSettings.ApiKey);

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<Root>(content);

                return json ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new();
        }
    }
}
