using Admin.Models;
using Refit;

namespace Admin.Abstractions
{
    public interface IApiOrdersService
    {
        [Post("/orders/askQuote")]
        Task<ApiResponse<QuoteViewModel>> GetQuote([Body(BodySerializationMethod.Serialized)] GetQuoteModel request);
    }
}
