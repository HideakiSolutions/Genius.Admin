using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
