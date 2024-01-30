using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public IActionResult Confirmmail()
        {
            return View();
        }
        public IActionResult Emailverification()
        {
            return View();
        }
        public IActionResult Lockscreen()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Recoverpw()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Twostepverification()
        {
            return View();
        }
    }
}