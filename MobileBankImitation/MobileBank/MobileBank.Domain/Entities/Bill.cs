namespace MobileBank.Domain.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }

        public int ProviderId { get; set; }

        //navigation properties
        public Provider Provider { get; set; }

    
        public Customer Customer { get; set; }

    }
}
