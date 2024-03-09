using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class OfferBookController : Controller
    {
        // GET: OfferBookControler
        public ActionResult Index()
        {
            return View();
        }

        // GET: OfferBookControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OfferBookControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferBookControler/Create
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

        // GET: OfferBookControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OfferBookControler/Edit/5
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

        // GET: OfferBookControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OfferBookControler/Delete/5
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

        [HttpGet]
        public BookViewModel Quotation(string productId)
        {

            BookViewModel book = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Store.AccessToken);
                client.BaseAddress = new Uri("https://sandbox.geniusbit.io/");

                //HTTP GET
                var responseTask = client.GetAsync($"quotes/{productId}/book");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonSerializer.DeserializeAsync<BookViewModel>(result.Content.ReadAsStreamAsync().Result);
                    //readTask.Wait();
                    book = readTask.Result;
                }
                else
                {
                    book = new BookViewModel();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

                return book;
            }
        }
    }
}
