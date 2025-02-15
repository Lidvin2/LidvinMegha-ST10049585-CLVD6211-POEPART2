using CLVD6211_POEPART2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLVD6211_POEPART2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            List<productTable> products = productTable.GetAllProducts();

            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult MyWork() 
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
