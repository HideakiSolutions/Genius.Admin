namespace Admin.Models
{
    public class TokenViewModel
    {
        public string currency              { get; set; }
        public string alias                 { get; set; }
        public string network               { get; set; }
        public int decimals                 { get; set; }
        public int networkDecimals          { get; set; }
        public bool singleAddress           { get; set; }
        public bool testNetwork             { get; set; }
        public string minDepositQuantity    { get; set; }
        public string minWithdrawalQuantity { get; set; }
    }
}
