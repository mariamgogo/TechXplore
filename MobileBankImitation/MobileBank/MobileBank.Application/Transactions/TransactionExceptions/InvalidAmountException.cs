namespace MobileBank.Application.Transactions.TransactionExceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) 
        {
            
        }
    }
}
