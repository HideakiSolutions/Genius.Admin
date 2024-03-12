namespace Admin.Models
{
    public class WithdrawalEstimateFee
    {
        public string currency  {  get; set; }
        public string network   { get; set; }
        public decimal fee      { get; set; }
        public Int64 timestamp  { get; set; }

    }
}
