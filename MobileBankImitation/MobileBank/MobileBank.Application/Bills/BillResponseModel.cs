namespace MobileBank.Application.Bills
{
    public class BillResponseModel
    {
        public decimal Amount { get; set; }
        public int ProviderId { get; set; }
        public int CustomerId { get; set; }
    }
}
