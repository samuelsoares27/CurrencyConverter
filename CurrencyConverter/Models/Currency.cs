
namespace CurrencyConverter.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public Double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
