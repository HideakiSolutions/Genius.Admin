using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public IActionResult Index()
        {
            return View();
        }
    }
}