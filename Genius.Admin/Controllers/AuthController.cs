using Admin;
using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Genius.Admin.Controllers
{
    public class AuthController : Controller
    {

        private readonly IApiLoginService _apiLoginService;

        public AuthController(IApiLoginService apiLoginService)
        {
            _apiLoginService = apiLoginService;
        }


        // GET: Auth
        public IActionResult Confirmmail()
        {
            return View();
        }
        public IActionResult Emailverification()
        {
            return View();
        }
        public IActionResult Lockscreen()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(LoginViewModel user)
        {
            AuthenticationRequestViewModel request = new AuthenticationRequestViewModel() { username = user.UserName, password = user.UserPassword };
            var result = await _apiLoginService.Login(request);

            if(!result.IsSuccessStatusCode)
                return View(user);

            Store.AccessToken = result.Content.access_token;

            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Recoverpw()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Twostepverification()
        {
            return View();
        }
    }
}