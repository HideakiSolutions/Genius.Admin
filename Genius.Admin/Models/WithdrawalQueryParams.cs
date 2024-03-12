using Refit;

namespace Admin.Models
{
    public class WithdrawalQueryParams
    {
        [AliasAs("customer_id")]
        public string CustomerId { get; set; }

    }
}
