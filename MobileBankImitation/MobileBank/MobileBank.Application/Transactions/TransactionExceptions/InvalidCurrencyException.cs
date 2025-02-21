namespace MobileBank.Application.Transactions.TransactionExceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string message):base(message) 
        {
            
        }
    }
}
