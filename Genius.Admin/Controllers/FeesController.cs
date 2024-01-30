using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class FeesController : Controller
    {
        // GET: FeesController
        public ActionResult Index()
        {
            FeeViewModel contatos = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("tokens/withdrawal-fee?currency=ETH&network=Ethereum");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<FeeViewModel>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = new FeeViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }

        // GET: FeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
