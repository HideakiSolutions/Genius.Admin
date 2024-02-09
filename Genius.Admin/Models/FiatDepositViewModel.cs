using Microsoft.IdentityModel.Tokens;
using System.Drawing;

namespace Admin.Models
{
    public class FiatDepositViewModel
    {
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public object bankAddress { get; set; }
        public string bankBranch { get; set; }
        public string bankName { get; set; }
        public string currency { get; set; }
        public object routingNumber { get; set; }
        public object swiftCode { get; set; }
        public string bankCode { get; set; }
        public string bankCompe { get; set; }
        public string pixQr { get; set; }
        public string accountHoldDocument { get; set; }

        public string QrCodeImage
        {
            get
            {

                if (!pixQr.IsNullOrEmpty())
                {
                    /*
                    byte[] imageBytes = Convert.FromBase64String(pixQr.Replace("data:image/png;base64,", String.Empty));
                    // Convert byte[] to Image
                    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                    {
                        Image image = Image.FromStream(ms, true);
                        return image;
                    }
                    */
                    return pixQr.Replace("=alt=", String.Empty);

                }

                return String.Empty;
            }
        }
    }
}
