namespace Admin.Models
{
    public class Account
    {
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public object bankCompe { get; set; }
        public string branchCode { get; set; }
        public object swiftCode { get; set; }
        public string accountHolder { get; set; }
        public string accountHolderDocument { get; set; }
        public object bankProofStatus { get; set; }
        public bool isSavings { get; set; }
    }

    public class Content
    {
        public string id { get; set; }
        public string externalId { get; set; }
        public string customerId { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public Account account { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }

    public class WithdrawalHistoryRootViewModel
    {
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public List<Content> content { get; set; }
    }

}
