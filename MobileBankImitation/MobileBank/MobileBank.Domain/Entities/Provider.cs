namespace MobileBank.Domain.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoLink { get; set; }

        //navigation property
        public List<Bill> Bills { get; set; }
    }
}
