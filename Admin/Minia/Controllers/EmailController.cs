using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public IActionResult Inbox()
        {
            return View();
        }
        public IActionResult Read()
        {
            return View();
        }
    }
}