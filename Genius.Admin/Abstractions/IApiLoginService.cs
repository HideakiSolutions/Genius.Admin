using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Admin.Abstractions
{
    public interface IApiLoginService
    {
        [Post("/auth/login")]
        Task<ApiResponse<BearerTokenViewModel>> Login([Body(BodySerializationMethod.UrlEncoded)] AuthenticationRequestViewModel request);
    }
}
