namespace TaiwanStockLookup.Models
{
    public class StockModel
    {
        public string StockCode { get; set; } = string.Empty;
        public string StockName { get; set; } = string.Empty;
        public decimal? ClosePrice { get; set; }
        public string Date { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class StockSearchModel
    {
        public string StockCode { get; set; } = string.Empty;
    }
}