using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class WalletsController : Controller
    {

        private readonly IApiWalletsService _apiWalletsService;

        public WalletsController(IApiWalletsService apiWalletsService)
        {
            _apiWalletsService = apiWalletsService;
        }
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

        public IEnumerable<BalanceModel> GetBalance(string customerId, string currencyId)
        {
            IEnumerable<BalanceModel> balances = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"wallets/balance?customer_id={customerId}&currency={currencyId}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IEnumerable<BalanceModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    balances = readTask.Result;
                }
                else
                {
                    balances = new List<BalanceModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                return balances;

            }
        }

        [HttpPost]
        public WithdrawalAddressResponse CreateWithdrawalAddress(string customer, [FromBody] WithdrawalAddressRequest request)
        {
            try
            {
                WithdrawalAddressQueryParams parameters = new WithdrawalAddressQueryParams() { CustomerId = customer };

                var result = _apiWalletsService.CreateWithdrawalAddress(request, parameters).Result;

                if (result.IsSuccessStatusCode)
                {
                    WithdrawalAddressResponse response = result.Content;
                    return response;
                }

                return new WithdrawalAddressResponse();
            }
            catch
            {
                return new WithdrawalAddressResponse();
            }
        }

        [HttpPost]
        public DepositAddressResponse CreateDepositAddress(string customer, [FromBody] DepositAddressRequest request)
        {
            try
            {
                DepositAddressQueryParams parameters = new DepositAddressQueryParams() { CustomerId = customer };

                var result = _apiWalletsService.CreateDepositAddress(request, parameters).Result;

                if (result.IsSuccessStatusCode)
                {
                    DepositAddressResponse response = result.Content;
                    return response;
                }

                return new DepositAddressResponse();
            }
            catch
            {
                return new DepositAddressResponse();
            }
        }

        [HttpPost]
        public WithdrawalResponse CreateWithdrawal(string customer, [FromBody] WithdrawalRequest request)
        {
            try
            {
                WithdrawalQueryParams parameters = new WithdrawalQueryParams() { CustomerId = customer };

                var result = _apiWalletsService.CreateWithdrawal(request, parameters).Result;

                if (result.IsSuccessStatusCode)
                {
                    WithdrawalResponse response = result.Content;
                    return response;
                }

                return new WithdrawalResponse();
            }
            catch
            {
                return new WithdrawalResponse();
            }
        }

        [HttpPost]
        public FiatWithdrawalResponse CreateFiatWithdrawal(string customer, [FromBody] FiatWithdrawalRequest request)
        {
            try
            {
                request.customerId = customer;

                var result = _apiWalletsService.CreateFiatWithdrawal(request).Result;

                if (result.IsSuccessStatusCode)
                {
                    FiatWithdrawalResponse response = result.Content;
                    return response;
                }

                return new FiatWithdrawalResponse();
            }
            catch
            {
                return new FiatWithdrawalResponse();
            }
        }

    }
}
