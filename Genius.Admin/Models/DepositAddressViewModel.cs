namespace Admin.Models
{
    public class DepositAddressViewModel
    {
        public int version              { get; set; }
        public long createdAt           { get; set; }
        public long updatedAt           { get; set; }
        public string id                { get; set; }
        public string entity            { get; set; }
        public string customerId        { get; set; }
        public string assetId           { get; set; }
        public string currency          { get; set; }
        public string address           { get; set; }
        public string network           { get; set; }
        public string destinationTag    { get; set; }
        public string status            { get; set; }
        public string signature         { get; set; }

    }
}
