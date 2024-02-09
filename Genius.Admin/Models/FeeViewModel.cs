namespace Admin.Models
{
    public class FeeViewModel
    {
        public string currency { get; set; }
        public string network { get; set; }
        public string fee { get; set; }
        public string timestamp { get; set; }

        public string dateTime
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateTime = dateTime.AddMilliseconds(Convert.ToInt64(timestamp)).ToLocalTime();
                return dateTime.ToString();
            }
        }
    }
}
