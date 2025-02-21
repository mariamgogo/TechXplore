namespace MobileBank.Application.Accounts.AccountExceptions
{
    public class AccountNotFoundException :Exception
    {
        public AccountNotFoundException(string message) : base(message) 
        {
            
        }
    }
}
