using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public IActionResult Google()
        {
            return View();
        }
        public IActionResult Leaflet()
        {
            return View();
        }
        public IActionResult Vector()
        {
            return View();
        }
    }
}