namespace MobileBank.Application.Bills.BillExceptions
{
    public class BillAlreadyExistsException :Exception
    {
        public BillAlreadyExistsException(string message):base(message) 
        {
            
        }
    }
}
