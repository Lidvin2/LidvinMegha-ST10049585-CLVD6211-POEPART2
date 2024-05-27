using CLVD6211_POEPART2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6211_POEPART2.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public IActionResult Login(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);

                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("LoginFailed");
            }
        }

        public IActionResult Index()
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
    }
}
