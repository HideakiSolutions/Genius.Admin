namespace Admin.Models
{
    public class WithdrawalAddressRequest
    {
        public string network { get; set; }
        public string currency { get; set; }
        public string address { get; set; }
        public string destinationTag { get; set; }
    }
}
