namespace MobileBank.Application.Bills
{
    public class BillResponseGetAllModel
    {
        public decimal Amount { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderLogo { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
    }
}
