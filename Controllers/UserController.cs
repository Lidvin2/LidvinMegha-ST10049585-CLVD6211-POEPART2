using CLVD6211_POEPART2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6211_POEPART2.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult Login(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(usrtbl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
