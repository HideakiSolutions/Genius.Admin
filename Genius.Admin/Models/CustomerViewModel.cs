namespace Admin.Models
{
    public class CustomerViewModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string status { get; set; }
        public string externalId { get; set; }
        public string kycStatus { get; set; }
    }
}
