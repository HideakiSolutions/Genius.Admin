namespace Admin.Models
{
    public class FiatWithdrawalAccount
    {
        public string bankName { get; set; }
        public bool isSavings { get; set; }
        public string bankIspb { get; set; }
        public string branch { get; set; }
        public string account { get; set; }
        public string holderName { get; set; }
        public string holderDocument { get; set; }
    }

    public class FiatWithdrawalRequest
    {
        public string customerId { get; set; }  
        public string externalId { get; set; }
        public string amount { get; set; }
        public FiatWithdrawalAccount account { get; set; }
    }
}
