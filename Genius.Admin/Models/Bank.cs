namespace Admin.Models
{
    public class Bank
    {
        public string ispbCode { get; set; }
        public string shortName { get; set; }
        public string code { get; set; }
        public string name { get; set; }

        public Bank(BankViewModel model)
        {
            this.ispbCode = model.ispbCode;
            this.shortName = model.shortName;
            this.code = model.code;
            this.name = model.name;
        }
    }
}
