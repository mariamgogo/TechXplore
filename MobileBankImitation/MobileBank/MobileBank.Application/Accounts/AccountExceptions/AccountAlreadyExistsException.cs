namespace MobileBank.Application.Accounts.AccountExceptions
{
    public class AccountAlreadyExistsException :Exception
    {
        public AccountAlreadyExistsException(string message):base(message)
        {
            
        }
    }
}
