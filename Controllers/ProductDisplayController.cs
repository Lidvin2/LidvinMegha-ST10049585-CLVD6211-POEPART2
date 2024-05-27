using CLVD6211_POEPART2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6211_POEPART2.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
