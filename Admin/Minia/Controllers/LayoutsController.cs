using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
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