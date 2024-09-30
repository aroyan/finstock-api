namespace FinStock.Models
{
    public class StockQuery : QueryParameters
    {
        public string? Symbol { get; set; } = string.Empty;
    }
}