using System.Text.Json.Serialization;

namespace MAUIApp.CurrencyExchange.Models
{
    public class Root
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; } = new();

        [JsonPropertyName("query")]
        public Query Query { get; set; } = new();

        [JsonPropertyName("result")]
        public double Result { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
