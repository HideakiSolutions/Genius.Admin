using Microsoft.AspNetCore.Mvc;

namespace Minia.Controllers
{
    public class DashboradController : Controller
    {
        // GET: Dashborad
        public IActionResult Index()
        {
            return View();
        }
    }
}