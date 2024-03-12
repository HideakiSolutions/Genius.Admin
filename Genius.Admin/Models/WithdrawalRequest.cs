namespace Admin.Models
{
    public class WithdrawalRequest
    {
        public string customerId { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string withdrawAddressId { get; set; }
        public string estimateFee { get; set; }
    }
}
