using Microsoft.AspNetCore.Mvc;

namespace Genius.Admin.Controllers
{
    public class LayoutsController : Controller
    {
        // GET: Layouts
        public IActionResult Index()
        {
            return View();
        }
    }
}