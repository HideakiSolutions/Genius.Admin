namespace Admin.Models
{
    public class OrderResponse
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
        public Int64 createdAt { get; set; }
        public Int64 updatedAt { get; set; }
    }
}
