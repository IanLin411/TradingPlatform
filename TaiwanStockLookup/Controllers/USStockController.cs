using Microsoft.AspNetCore.Mvc;
using TaiwanStockLookup.Models;

namespace TaiwanStockLookup.Controllers
{
    public class USStockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}