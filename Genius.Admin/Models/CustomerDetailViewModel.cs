namespace Admin.Models
{
    public class CustomerDetailViewModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string status { get; set; }
        public string externalId { get; set; }
        public string kycStatus { get; set; }
        public OrdersRootViewModel orders { get; set; }
        public IEnumerable<BalanceViewModel> balances { get; set; }
        public IEnumerable<TokenViewModel> tokens { get; set; }
        public IEnumerable<WithdrawalAddressViewModel> withdrawalAddresses { get; set; }
        public WithdrawalHistoryRootViewModel withdrawalHistory { get; set; }
        public IEnumerable<DepositAddressViewModel> depositAddresses { get; set; }
        public IEnumerable<FiatDepositViewModel> depositInformations { get; set; }
        public DepositHistoryRootViewModel depositHistory { get; set; }
        public string available {  get; set; }

    }
}
