using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IApiOrdersService _apiOrdersService;

        public OrdersController(IApiOrdersService apiOrdersService)
        {
            _apiOrdersService = apiOrdersService;
        }

        // GET: OrdersController
        public ActionResult Index()
        {
            OrdersRootViewModel contatos = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("orders?customer_id=jv3e8qrlt4o6ps");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<OrdersRootViewModel>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = new OrdersRootViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }

        [HttpPost]
        public OrderResponse SendOrder([FromBody] OrderModel request)
        {
            try
            {
                var result = _apiOrdersService.SendOrder(request).Result;

                if (result.IsSuccessStatusCode)
                {
                    OrderResponse response = result.Content;
                    return response;
                }

                return new OrderResponse();
            }
            catch
            {
                return new OrderResponse();
            }
        }
    }
}
