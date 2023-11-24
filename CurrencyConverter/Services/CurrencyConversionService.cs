using CurrencyConverter.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace CurrencyConverter.Services
{
    public class CurrencyConversionService
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _apiKey = "5a2208dd4b70467ba434a5c448e0cf2b";

        public CurrencyConversionService(){ }

        public async Task<decimal> ConvertCurrencyAsync(string fromCurrency, string toCurrency, decimal amount)
        {
            string apiUrl = $"https://open.er-api.com/v6/latest?app_id={_apiKey}";

            var response = await _httpClient.GetFromJsonAsync<OpenExchangeResponse>(apiUrl);

            if (response.Rates.TryGetValue(toCurrency, out var toRate) &&
                response.Rates.TryGetValue(fromCurrency, out var fromRate))
            {
                // Convert amount
                var convertedAmount = amount * (toRate / fromRate);
                return convertedAmount;
            }

            throw new InvalidOperationException("Invalid currency codes");
        }

        public async Task<Dictionary<string, decimal>> ListCurrency()
        {
            string apiUrl = $"https://open.er-api.com/v6/latest?app_id={_apiKey}";

            var response = await _httpClient.GetFromJsonAsync<OpenExchangeResponse>(apiUrl);
            return response.Rates;
        }

    }
}
