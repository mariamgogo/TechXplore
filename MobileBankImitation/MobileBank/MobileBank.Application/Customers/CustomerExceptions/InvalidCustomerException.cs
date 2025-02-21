namespace MobileBank.Application.Customers.CustomerExceptions
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string message) : base(message)
        {
            
        }
    }
}
