using Refit;

namespace Admin.Models
{
    public class DepositAddressQueryParams
    {
        [AliasAs("customer_id")]
        public string CustomerId { get; set; }
    }
}
