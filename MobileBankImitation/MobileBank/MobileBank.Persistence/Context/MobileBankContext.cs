using Microsoft.EntityFrameworkCore;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Context
{
    public class MobileBankContext: DbContext
    {
        public MobileBankContext(DbContextOptions<MobileBankContext> options): base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Provider> Providers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MobileBankContext).Assembly);
        }
    }
}
