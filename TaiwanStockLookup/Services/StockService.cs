using TaiwanStockLookup.Models;
using System.Text.Json;

namespace TaiwanStockLookup.Services
{
    public class StockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StockModel> GetStockPriceAsync(string stockCode)
        {
            try
            {
                // 使用台灣證交所API或其他股票資訊API
                // 這裡使用模擬資料作為示例
                var stockModel = new StockModel
                {
                    StockCode = stockCode,
                    StockName = GetStockName(stockCode),
                    ClosePrice = GetMockClosePrice(stockCode),
                    Date = DateTime.Now.ToString("yyyy-MM-dd")
                };

                // 實際應用中，這裡應該呼叫真實的API
                // 例如: 台灣證交所API、Yahoo Finance API等
                await Task.Delay(100); // 模擬API呼叫延遲

                return stockModel;
            }
            catch (Exception ex)
            {
                return new StockModel
                {
                    StockCode = stockCode,
                    ErrorMessage = $"查詢股票資訊時發生錯誤: {ex.Message}"
                };
            }
        }

        private string GetStockName(string stockCode)
        {
            // 模擬股票名稱對應
            var stockNames = new Dictionary<string, string>
            {
                { "2330", "台積電" },
                { "2317", "鴻海" },
                { "2454", "聯發科" },
                { "2308", "台達電" },
                { "2412", "中華電" },
                { "2881", "富邦金" },
                { "2882", "國泰金" },
                { "2886", "兆豐金" },
                { "2303", "聯電" },
                { "2002", "中鋼" }
            };

            return stockNames.TryGetValue(stockCode, out var name) ? name : "未知股票";
        }

        private decimal GetMockClosePrice(string stockCode)
        {
            // 模擬股價資料
            var random = new Random();
            var basePrice = stockCode switch
            {
                "2330" => 500m,
                "2317" => 100m,
                "2454" => 800m,
                "2308" => 300m,
                "2412" => 120m,
                "2881" => 60m,
                "2882" => 50m,
                "2886" => 35m,
                "2303" => 45m,
                "2002" => 25m,
                _ => 100m
            };

            // 添加隨機變動
            var variation = (decimal)(random.NextDouble() * 0.1 - 0.05); // -5% to +5%
            return Math.Round(basePrice * (1 + variation), 2);
        }
    }
}