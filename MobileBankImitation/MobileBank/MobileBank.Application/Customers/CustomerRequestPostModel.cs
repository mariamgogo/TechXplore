namespace MobileBank.Application.Customers
{
    public class CustomerRequestPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
}
