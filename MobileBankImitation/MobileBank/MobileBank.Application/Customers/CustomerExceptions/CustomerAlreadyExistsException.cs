namespace MobileBank.Application.Customers.CustomerExceptions
{
    public class CustomerAlreadyExistsException : Exception
    {
        public CustomerAlreadyExistsException(string message) : base(message) 
        {
            
        }
    }
}
