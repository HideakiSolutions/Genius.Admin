using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class InvoicesController : Controller
    {
        // GET: Invoices
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}