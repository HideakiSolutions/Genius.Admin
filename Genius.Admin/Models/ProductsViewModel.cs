namespace Admin.Models
{
    public class ProductsViewModel
    {
        public string productId     { get; set; }
        public string baseCurrency  { get; set; }
        public string quoteCurrency { get; set; }
        public int priceDecimals { get; set; }
        public int sizeDecimals  { get; set; }
        public string minOrderSize  { get; set; }
    }
}
