using Microsoft.AspNetCore.Mvc;

namespace Genius.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public IActionResult customers()
        {
            return View();
        }

        public IActionResult transactions()
        {
            return View();
        }

        public IActionResult fiats()
        {
            return View();
        }

        public IActionResult banks()
        {
            return View();
        }
    }
}