namespace MobileBank.Application.Transactions.TransactionExceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(string message) :base(message) 
        {
            
        }
    }
}
