using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> contatos = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IList<CustomerViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<CustomerViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string id)
        {
            CustomerDetailViewModel customer = new CustomerDetailViewModel() { id = id };
            OrdersRootViewModel orders = null;
            IEnumerable<BalanceViewModel> balances = null;
            IEnumerable<TokenViewModel> tokens = null;
            IEnumerable<WithdrawalAddressViewModel> withdrawalAddresses = null;
            IEnumerable<DepositAddressViewModel> depositAddresses = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"customers/{id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<CustomerDetailViewModel>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    customer = readTask.Result;
                }
                else
                {
                    customer = new CustomerDetailViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"orders?customer_id={id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<OrdersRootViewModel>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    orders = readTask.Result;
                }
                else
                {
                    orders = new OrdersRootViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                customer.orders = orders;

                
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"wallets/balance?customer_id={id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<BalanceViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    balances = readTask.Result;
                }
                else
                {
                    balances = new List<BalanceViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                customer.balances = balances;

                if (balances.Count() > 0 )
                {
                    if(balances.Any(balance => balance.currency.Equals("USDT")))
                    {
                        customer.available = balances.Where(balance => balance.currency.Equals("USDT")).FirstOrDefault().available;
                    }    
                }    
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"tokens");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<TokenViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    tokens = readTask.Result;
                }
                else
                {
                    tokens = new List<TokenViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                if (tokens.Count() > 0)
                {
                    customer.tokens = tokens;
                }
            }

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

                customer.withdrawalAddresses = withdrawalAddresses;
            }
            
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

                customer.depositAddresses = depositAddresses;

            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
