using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public IActionResult Grid()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult profile()
        {
            return View();
        }
    }
}