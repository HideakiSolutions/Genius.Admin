using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        public IActionResult Apex()
        {
            return View();
        }
        public IActionResult Chartjs()
        {
            return View();
        }
        public IActionResult Echart()
        {
            return View();
        }
        public IActionResult Knob()
        {
            return View();
        }
        public IActionResult Sparkline()
        {
            return View();
        }
    }
}