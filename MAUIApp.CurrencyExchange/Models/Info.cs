using System.Text.Json.Serialization;

namespace MAUIApp.CurrencyExchange.Models
{
    public class Info
    {
        [JsonPropertyName("rate")]
        public double Rate { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
    }
}
