namespace Admin.Models
{
    public class BookViewModel
    {
        public string productId { get; set; }
        public long timestamp { get; set; }
        public List<List<string>> bids { get; set; }
        public List<List<string>> asks { get; set; }
    }
}
