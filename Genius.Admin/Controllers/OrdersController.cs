using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
            OrdersRootViewModel orders = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("http://localhost:8000/");

                //HTTP GET
                var responseTask = client.GetAsync("orders?customer_id=jv3e8qrlt4o6ps");
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
                return View(orders);
            }
        }

        public IEnumerable<Order> GetOrders(string customerId)
        {
            OrdersRootViewModel orders = null;
            List<Order> response = new List<Order>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("http://localhost:8000/");

                //HTTP GET
                var responseTask = client.GetAsync($"orders?customer_id={customerId}&page_num=1&page_size=10");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<OrdersRootViewModel>(result.Content.ReadAsStreamAsync().Result);
                    orders = readTask.Result;

                    if (orders.totalPages > 1)
                    {
                        Int32 count = orders.totalPages;

                        for (int i = 2; i <= count;)
                        {
                            responseTask = client.GetAsync($"orders?customer_id={customerId}&page_num={i}&page_size=10");
                            responseTask.Wait();
                            result = responseTask.Result;

                            if (result.IsSuccessStatusCode)
                            {
                                readTask = JsonSerializer.DeserializeAsync<OrdersRootViewModel>(result.Content.ReadAsStreamAsync().Result);
                                orders.content.AddRange(readTask.Result.content);
                            }
                        }
                    }
                }
                else
                {
                    orders = new OrdersRootViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
            }

            if(orders.content.Count > 0)
            {
                response.AddRange(orders.content.Select(order => new Order()));
            }

            return response;
        }

        [HttpPost]
        public OrderResponse SendOrder([FromBody] TradeRequest request)
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
