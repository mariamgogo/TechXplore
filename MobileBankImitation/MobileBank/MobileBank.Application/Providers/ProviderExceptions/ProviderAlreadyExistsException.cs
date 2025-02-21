namespace MobileBank.Application.Providers.ProviderExceptions
{
    public class ProviderAlreadyExistsException : Exception
    {
        public ProviderAlreadyExistsException(string message) : base(message) 
        {
            
        }
    }
}
