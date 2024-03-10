namespace Admin.Models
{
    public class Product
    {
        public string productId { get; set; }
        public string baseCurrency { get; set; }
        public string quoteCurrency { get; set; }
        public int priceDecimals { get; set; }
        public int sizeDecimals { get; set; }
        public string minOrderSize { get; set; }

        public Product(ProductsViewModel product)
        {
            productId       = product.productId;
            baseCurrency    = product.baseCurrency;
            quoteCurrency   = product.quoteCurrency;
            priceDecimals   = product.priceDecimals;
            sizeDecimals    = product.sizeDecimals;
            minOrderSize    = product.minOrderSize;
        }
    }
}
