using Admin.Models;
using Refit;

namespace Admin.Abstractions
{
    public interface IApiWalletsService
    {
        [Post("/wallets/withdrawal-address")]
        Task<ApiResponse<WithdrawalAddressResponse>> CreateWithdrawalAddress([Body(BodySerializationMethod.Serialized)] WithdrawalAddressRequest request, WithdrawalAddressQueryParams parameters);

        [Post("/wallets/deposit-address")]
        Task<ApiResponse<DepositAddressResponse>> CreateDepositAddress([Body(BodySerializationMethod.Serialized)] DepositAddressRequest request, DepositAddressQueryParams parameters);

        [Post("/wallets/withdrawal")]
        Task<ApiResponse<WithdrawalResponse>> CreateWithdrawal([Body(BodySerializationMethod.Serialized)] WithdrawalRequest request, WithdrawalQueryParams parameters);
    }
}
