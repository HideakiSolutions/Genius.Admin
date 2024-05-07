namespace Admin.Models
{
    public class PersonalCustomer
    {
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string documentType { get; set; }
        public string birthDate { get; set; }
        public string cpfCnpj { get; set; }
        public string motherName { get; set; }
        public string occupation { get; set; }
        public string declaredIncome { get; set; }
        public string declaredIncomeB64 { get; set; }
        public Address address { get; set; }
        public string addressB64 { get; set; }
        public string[] documentB64 { get; set; }
        public string documentFrontB64 { get; set; }
        public string documentBackB64 { get; set; }
        public string selfieB64 { get; set; }
        public string isPep { get; set; }
        public string externalId { get; set; }
    }
}
