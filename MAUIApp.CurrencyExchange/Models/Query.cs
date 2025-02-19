using System.Text.Json.Serialization;

namespace MAUIApp.CurrencyExchange.Models
{
    public class Query
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }
    }
}
