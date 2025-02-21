namespace MobileBank.Application.Transactions
{
    public class TransactionRequestModel
    {
        public DateTime TransactionDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
    }
}
