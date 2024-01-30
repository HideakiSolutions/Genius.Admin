namespace Admin.Models
{
    public class WithdrawalAddressViewModel
    {
        public string id { get; set; }
        public string customerId { get; set; }
        public string currency { get; set; }
        public string address { get; set; }
        public string destinationTag { get; set; }
        public string network { get; set; }
    }
}
