namespace Admin.Models
{
    public class FiatWithdrawalAccountResponse
    {
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string bankCompe { get; set; }
        public string branchCode { get; set; }
        public string swiftCode { get; set; }
        public string accountHolder { get; set; }
        public string accountHolderDocument { get; set; }
        public string bankProofStatus { get; set; }
        public bool isSavings { get; set; }
    }

    public class FiatWithdrawalResponse
    {
        public string id { get; set; }
        public string externalId { get; set; }
        public string customerId { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public FiatWithdrawalAccountResponse account { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public string value { get; set; }
    }

}
