using Admin.Models;

namespace Admin
{
    public class Store
    {
        public static string AccessToken { get; set; }
        public static IEnumerable<Product> Products { get; set; }
    }
}
