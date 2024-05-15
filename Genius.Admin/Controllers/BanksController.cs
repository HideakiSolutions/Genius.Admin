using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class BanksController : Controller
    {
        // GET: BanksController
        public ActionResult Index()
        {
            IEnumerable<BankViewModel> banks = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("fiat/banks");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IList<BankViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    banks = readTask.Result;
                }
                else
                {
                    banks = Enumerable.Empty<BankViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(banks);
            }
        }


        public IEnumerable<Bank> GetBanks()
        {
            IEnumerable<BankViewModel> banks = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("fiat/banks");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IList<BankViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    banks = readTask.Result;
                }
                else
                {
                    banks = Enumerable.Empty<BankViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return banks.Select(bank => new Bank(bank));
            }
        }
        // GET: BanksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BanksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanksController/Create
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

        // GET: BanksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BanksController/Edit/5
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

        // GET: BanksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BanksController/Delete/5
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
