namespace Admin.Models
{
    public class BusinessCustomer
    {
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string fullName { get; set; }
        public string legalName { get; set; }
        public string tradingName { get; set; }
        public string businessType { get; set; }
        public string companySize{ get; set; }
        public string cnaeCode { get; set; }
        public string website { get; set; }
        public string declaredAnnualRevenue { get; set; }
        public string cpfCnpj { get; set; }
        public string motherName { get; set; }
        public string occupation { get; set; }
        public string declaredIncome { get; set; }
        public string declaredIncomeB64 { get; set; }
        public Address address { get; set; }
        public string addressB64 { get; set; }
        public string[] companyStatuteB64 { get; set; }
        public companyAssociate[] companyAssociates { get; set; }
        public string externalId { get; set; }
    }

    public class companyAssociate
    {
        public string cpfCnpj { get; set; }
        public string[] documentB64 { get; set; }
        public string[] companyStatuteB64 { get; set; }
        public string[] declaredIncomeB64 { get; set; }
    }
}
