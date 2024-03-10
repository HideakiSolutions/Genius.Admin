using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            IEnumerable<ProductsViewModel> contatos = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("quotes/products");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IList<ProductsViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<ProductsViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }

        public Product GetProduct(string product)
        {
            if(Store.Products is null)
            {
                IEnumerable<ProductsViewModel> products = null;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                    client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                    //HTTP GET
                    var responseTask = client.GetAsync("quotes/products");
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = JsonSerializer.DeserializeAsync<IList<ProductsViewModel>>(result.Content.ReadAsStreamAsync().Result);
                        products = readTask.Result;
                        Store.Products = products.ToList().Select(product => new Product(product));
                    }
                    else
                    {
                        products = Enumerable.Empty<ProductsViewModel>();
                        ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                    }
                }
            }

            return Store.Products.Where(product => product.productId.Equals(product)).FirstOrDefault();

        }

    }
}
