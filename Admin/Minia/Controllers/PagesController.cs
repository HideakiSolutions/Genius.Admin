using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult Error500()
        {
            return View();
        }
        public IActionResult comingsoon()
        {
            return View();
        }
        public IActionResult faqs()
        {
            return View();
        }
        public IActionResult maintenance()
        {
            return View();
        }
        public IActionResult pricing()
        {
            return View();
        }
        public IActionResult starter()
        {
            return View();
        }
        public IActionResult timeline()
        {
            return View();
        }
    }
}