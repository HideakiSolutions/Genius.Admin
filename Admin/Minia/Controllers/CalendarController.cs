using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public IActionResult Index()
        {
            return View();
        }
    }
}