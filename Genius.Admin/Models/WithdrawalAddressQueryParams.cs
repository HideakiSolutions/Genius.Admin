using Refit;

namespace Admin.Models
{
    public class WithdrawalAddressQueryParams
    {
        [AliasAs("customer_id")]
        public string CustomerId { get; set; }
    }
}
