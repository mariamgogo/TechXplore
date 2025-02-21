namespace MobileBank.Application.Bills
{
    public class BillRequestModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }

        public int ProviderId { get; set; }
    }
}
