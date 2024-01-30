using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class WalletsController : Controller
    {
        // GET: AddressesController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WithdrawallAddress(string id)
        {
            IEnumerable<WithdrawalAddressViewModel> withdrawalAddresses = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"wallets/withdrawal-address?customer_id={id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<WithdrawalAddressViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    withdrawalAddresses = readTask.Result;
                }
                else
                {
                    withdrawalAddresses = new List<WithdrawalAddressViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                
                return View(withdrawalAddresses);
            }
        }

        public ActionResult DepositAddress(int id)
        {
            IEnumerable<DepositAddressViewModel> depositAddresses = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"wallets/deposit-address?customer_id={id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<DepositAddressViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    depositAddresses = readTask.Result;
                }
                else
                {
                    depositAddresses = new List<DepositAddressViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                return View(depositAddresses);

            }
        }

        // GET: AddressesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddressesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressesController/Create
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

        // GET: AddressesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressesController/Edit/5
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

        // GET: AddressesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressesController/Delete/5
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
