namespace MobileBank.Application.Bills.BillExceptions
{
    public class BillNotFoundException :Exception
    {
        public BillNotFoundException(string message) : base(message) 
        {
            
        }
    }
}
