using CLVD6211_POEPART2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6211_POEPART2.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();

        [HttpPost]
        public IActionResult MyWork(productTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MyWork()
        {
            return View(prodtbl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
