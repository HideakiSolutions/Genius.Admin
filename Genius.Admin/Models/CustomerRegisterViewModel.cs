namespace Admin.Models
{
    public class Address
    {
        public Address()
        {
            state = "SP";
            country = "BR";
        }

        public string street        { get; set; }
        public string number        { get; set; }
        public string district      { get; set; }
        public string city          { get; set; }
        public string state         { get; set; }
        public string zip           { get; set; }
        public string complement    { get; set; }
        public string country       { get; set; }
    }

    public class CustomerRegisterViewModel
    {
        public CustomerRegisterViewModel() 
        {
            
            documentType = "idcard";
            occupation = "OCP0001";
            isPep = "NONE";
            declaredIncome = "LESS_THAN_ONE_THOUSAND";
            userType = "personal";
        }

        public string email             { get; set; }
        public string phoneNumber       { get; set; }
        public string lastName          { get; set; }
        public string firstName         { get; set; }
        public string userType          { get; set; }
        public string documentType      { get; set; }
        public string birthDate         { get; set; }
        public string cpfCnpj           { get; set; }
        public string motherName        { get; set; }
        public string occupation        { get; set; }
        public string declaredIncome    { get; set; }
        public string declaredIncomeB64 { get; set; }
        public Address address          { get; set; }
        public string addressB64        { get; set; }
        public string documentFrontB64  { get; set; }
        public string documentBackB64   { get; set; }
        public string[] documentB64     { get; set; }
        public string selfieB64         { get; set; }
        
        public string isPep             { get; set; }
        public string externalId        { get; set; }
    }

}
