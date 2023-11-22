using System.Collections.Generic;

namespace CurrencyConverter.Models
{
    public class OpenExchangeResponse
    {
        public string Disclaimer { get; set; } = string.Empty;
        public string License { get; set; } = string.Empty;
        public long Timestamp { get; set; }
        public string Base { get; set; } = string.Empty;
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
