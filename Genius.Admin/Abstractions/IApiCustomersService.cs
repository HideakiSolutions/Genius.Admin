using Admin.Models;
using Refit;

namespace Admin.Abstractions
{
    public interface IApiCustomersService
    {
        [Post("/wallets/withdrawal-address")]
        Task<ApiResponse<CustomerViewModel>> Register([Body(BodySerializationMethod.Serialized)] CustomerRegisterViewModel request);
    }
}
