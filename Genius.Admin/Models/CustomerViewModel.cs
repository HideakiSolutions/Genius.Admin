namespace Admin.Models
{
    public class CustomerViewModel
    {
        public string id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string legalName { get; set; }
        public string cnaeName { get; set; }
        public string cpfCnpj { get; set; }
        public string tradingName { get; set; }

        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string status { get; set; }
        public string externalId { get; set; }
        public string kycStatus { get; set; }
        public string customerType { get; set; }
    }
}
