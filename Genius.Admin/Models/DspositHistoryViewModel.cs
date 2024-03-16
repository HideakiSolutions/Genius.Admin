namespace Admin.Models
{
    public class DepositHistoryContent
    {
        public string id { get; set; }
        public string customerId { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public object createdAt { get; set; }
        public object updatedAt { get; set; }
    }

    public class DepositHistoryRootViewModel
    {
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public List<DepositHistoryContent> content { get; set; }
    }

}
