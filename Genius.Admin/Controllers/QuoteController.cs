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

        [HttpGet]
        public QuoteViewModel AskQuote(string side, string productId, string size)
        {
            try
            {
                GetQuoteModel request = new GetQuoteModel()
                {
                    productId = productId,
                    size = size,
                    side = side
                };

                var result = _apiOrdersService.AskQuote(request).Result;

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
    }
}
