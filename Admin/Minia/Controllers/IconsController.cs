using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class IconsController : Controller
    {
        // GET: Icons
        public IActionResult Boxicons()
        {
            return View();
        }
        public IActionResult Dripicons()
        {
            return View();
        }
        public IActionResult Fontawesome()
        {
            return View();
        }
        public IActionResult Materialdesign()
        {
            return View();
        }
    }
}