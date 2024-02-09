using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IApiRegisterCustomerService _apiRegisterService;

        public CustomersController(IApiRegisterCustomerService apiRegisterService)
        {
            _apiRegisterService = apiRegisterService;
        }

        public ActionResult Register()
        {
            ViewBag.Occupations = new List<string>()
            {
                "OCP0001", "OCP0002", "OCP0003", "OCP0004", "OCP0005", "OCP0006", "OCP0007", "OCP0008", "OCP0009", "OCP0010",
                "OCP0011", "OCP0012", "OCP0013", "OCP0014", "OCP0015", "OCP0016", "OCP0017", "OCP0018", "OCP0019", "OCP0020",
                "OCP0021", "OCP0022", "OCP0023", "OCP0024", "OCP0025", "OCP0026", "OCP0027", "OCP0028", "OCP0029", "OCP0030",
                "OCP0031", "OCP0032", "OCP0033", "OCP0034", "OCP0035", "OCP0036", "OCP0037", "OCP0038", "OCP0039", "OCP0040",
                "OCP0041", "OCP0042", "OCP0043", "OCP0044", "OCP0045", "OCP0046", "OCP0047", "OCP0048", "OCP0049", "OCP0050",
                "OCP0051", "OCP0052", "OCP0053", "OCP0054", "OCP0055", "OCP0056", "OCP0057", "OCP0058", "OCP0059", "OCP0060",
                "OCP0061", "OCP0062", "OCP0063", "OCP0064", "OCP0065", "OCP0066", "OCP0067", "OCP0068", "OCP0069", "OCP0070",
                "OCP0071", "OCP0072", "OCP0073", "OCP0074", "OCP0075", "OCP0076", "OCP0077", "OCP0078", "OCP0079", "OCP0080",
                "OCP0081", "OCP0082", "OCP0083", "OCP0084", "OCP0085", "OCP0086", "OCP0087", "OCP0088", "OCP0089", "OCP0090",
                "OCP0091", "OCP0092", "OCP0093", "OCP0094", "OCP0095", "OCP0096", "OCP0097", "OCP0098", "OCP0099", "OCP0100",
                "OCP0101", "OCP0102", "OCP0103", "OCP0104", "OCP0105"
            };

            ViewBag.DeclaredIncomes = new List<string>()
            {
                "LESS_THAN_ONE_THOUSAND", "FROM_ONE_THOUSAND_TO_TWO_THOUSAND", "FROM_TWO_THOUSAND_TO_THREE_THOUSAND", "FROM_THREE_THOUSAND_TO_FIVE_THOUSAND", "FROM_FIVE_THOUSAND_TO_TEN_THOUSAND", "FROM_TEN_THOUSAND_TO_TWENTY_THOUSAND", "OVER_TWENTY_THOUSAND"
            };

            ViewBag.PepOptions = new List<string>()
            {
                "NONE", "SELF", "RELATED"
            };

            ViewBag.DocumentTypes = new List<string>()
            {
                "idcard", "driverlicense", "rne", "crnm", "dni", "passport"
            };

            ViewBag.UserTypes = new List<string>()
            {
                "personal", "business"
            };

            ViewBag.Countries = new List<string>()
            {
                "BR", "-"
            };

            ViewBag.States = new List<string>()
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE"
            };

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
            IEnumerable<FiatDepositViewModel> depositInformations = null;

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

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"fiat/deposit?customer_id={id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<FiatDepositViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    depositInformations = readTask.Result;
                }
                else
                {
                    depositInformations = new List<FiatDepositViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                customer.depositInformations = depositInformations;

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
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<dynamic>> Create(CustomerRegisterViewModel register)
        {
            try
            {
                if(!register.documentBackB64.IsNullOrEmpty() || !register.documentBackB64.IsNullOrEmpty())
                {
                    register.documentB64 = (new string[] { register.documentFrontB64, register.documentBackB64 });
                }

                register.externalId = register.cpfCnpj.Replace(".", String.Empty).Replace("-", String.Empty).Trim();
                register.phoneNumber = register.phoneNumber.Replace("(", String.Empty).Replace(")", String.Empty).Trim();


                var result = await _apiRegisterService.Register(register);

                if (!result.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

                return RedirectToAction("Index", "Dashboard");
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
