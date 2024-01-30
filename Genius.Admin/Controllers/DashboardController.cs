using Microsoft.AspNetCore.Mvc;

namespace Genius.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashborad
        public IActionResult Index()
        {
            return View();
        }
    }
}