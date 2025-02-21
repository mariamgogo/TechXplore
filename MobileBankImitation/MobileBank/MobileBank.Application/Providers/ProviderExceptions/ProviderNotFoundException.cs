namespace MobileBank.Application.Providers.ProviderExceptions
{
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException(string message) :base(message)
        {
            
        }
    }
}
