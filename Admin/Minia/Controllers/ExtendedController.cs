using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class ExtendedController : Controller
    {
        // GET: Extended
        public IActionResult Lightbox()
        {
            return View();
        }
        public IActionResult Notifications()
        {
            return View();
        }
        public IActionResult Rangeslider()
        {
            return View();
        }
        public IActionResult Rating()
        {
            return View();
        }
        public IActionResult Sessiontimeout()
        {
            return View();
        }
        public IActionResult Sweetalert()
        {
            return View();
        }
    }
}