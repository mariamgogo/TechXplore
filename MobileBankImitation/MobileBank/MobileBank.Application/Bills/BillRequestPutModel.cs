namespace MobileBank.Application.Bills
{
    public class BillRequestPutModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }

        public int ProviderId { get; set; }
    }
}
