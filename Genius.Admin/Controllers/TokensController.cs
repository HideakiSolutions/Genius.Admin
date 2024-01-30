using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class TokensController : Controller
    {
        public ActionResult Index()
        {   
            IEnumerable<TokenViewModel> contatos = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync("tokens");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<IList<TokenViewModel>>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<TokenViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }
    }
}
