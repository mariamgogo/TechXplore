namespace MobileBank.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

        //navigation property
        public List<Account> Accounts { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
