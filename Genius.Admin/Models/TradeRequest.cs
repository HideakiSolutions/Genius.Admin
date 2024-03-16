namespace Admin.Models
{
    public class TradeRequest
    {
        public string customerId { get; set; }
        public string productId { get; set; }
        public string side { get; set; }
        public string price { get; set; }
        public string size { get; set; }
        public string externalId { get; set; }
        public string depositMethod { get; set; }
    }
}
