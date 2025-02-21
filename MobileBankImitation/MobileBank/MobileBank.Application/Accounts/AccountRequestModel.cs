namespace MobileBank.Application.Accounts
{
    public class AccountRequestModel
    {
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public DateTime OpenDate { get; set; }
    }
}
