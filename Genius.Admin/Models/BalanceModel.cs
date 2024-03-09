namespace Admin.Models
{
    public class BalanceModel
    {
        public string id { get; set; }
        public string type { get; set; }
        public string customerId { get; set; }
        public string userId { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public string balance { get; set; }
        public string available { get; set; }
        public string hold { get; set; }
        public string pending { get; set; }
    }
}
