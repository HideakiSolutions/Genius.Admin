using Admin.Models;
using Refit;

namespace Admin.Abstractions
{
    public interface IApiCustomersService
    {
        [Post("/customers")]
        Task<ApiResponse<CustomerViewModel>> Register([Body(BodySerializationMethod.Serialized)] CustomerRegisterViewModel request);

        [Post("/customers/personalCustomer")]
        Task<ApiResponse<CustomerViewModel>> RegisterPersonal([Body(BodySerializationMethod.Serialized)] PersonalCustomer request);

        [Post("/customers/businessCustomer")]
        Task<ApiResponse<CustomerViewModel>> RegisterBusiness([Body(BodySerializationMethod.Serialized)] BusinessCustomer request);
    }
}
