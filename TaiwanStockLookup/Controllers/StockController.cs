using Microsoft.AspNetCore.Mvc;
using TaiwanStockLookup.Models;
using TaiwanStockLookup.Services;

namespace TaiwanStockLookup.Controllers
{
    public class StockController : Controller
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            return View(new StockSearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> Search(StockSearchModel searchModel)
        {
            if (string.IsNullOrWhiteSpace(searchModel.StockCode))
            {
                ModelState.AddModelError("StockCode", "請輸入股票代號");
                return View("Index", searchModel);
            }

            var stockInfo = await _stockService.GetStockPriceAsync(searchModel.StockCode);
            return View("Result", stockInfo);
        }
    }
}