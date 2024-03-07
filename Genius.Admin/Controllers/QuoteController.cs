using Admin.Abstractions;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Admin.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IApiOrdersService _apiOrdersService;

        public QuoteController(IApiOrdersService apiOrdersService)
        {
            _apiOrdersService = apiOrdersService;
        }

        // GET: QuoteController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public QuoteViewModel AskQuote([FromBody] GetQuoteModel request)
        {
            try
            {
                request.productId = $"{request.productId}_BRL";

                var result = _apiOrdersService.GetQuote(request).Result;

                if (result.IsSuccessStatusCode)
                {
                    QuoteViewModel resultViewModel = result.Content;
                    return resultViewModel;
                }

                return new QuoteViewModel();
            }
            catch
            {
                return new QuoteViewModel();
            }
        }

        // GET: QuoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuoteController/Create
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

        // GET: QuoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuoteController/Edit/5
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

        // GET: QuoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuoteController/Delete/5
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
