namespace MobileBank.Application.Customers.CustomerExceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message):base(message) 
        {
            
        }
    }
}
