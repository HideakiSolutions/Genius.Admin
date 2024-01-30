using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public IActionResult Basic()
        {
            return View();
        }
        public IActionResult Datatable()
        {
            return View();
        }
        public IActionResult Editable()
        {
            return View();
        }
        public IActionResult Responsive()
        {
            return View();
        }
    }
}