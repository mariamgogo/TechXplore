namespace MobileBank.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }

        //navigation properties
        public Account DebitAccount { get; set; }
        public Account CreditAccount { get; set; }
    }
}
