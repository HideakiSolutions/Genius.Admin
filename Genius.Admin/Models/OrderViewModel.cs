namespace Admin.Models
{
    public class OrdersContent
    {
        public string customerId { get; set; }
        public string orderId { get; set; }
        public string externalId { get; set; }
        public string productId { get; set; }
        public string side { get; set; }
        public string size { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string rejectReason { get; set; }
        public string amount 
        { 
            get 
            {
                return (Convert.ToDecimal(size) * Convert.ToDecimal(price)).ToString();
            }
            set { } 
        }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }

    public class OrdersRootViewModel
    {
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public List<OrdersContent> content { get; set; }
    }

}
