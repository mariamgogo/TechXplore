using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;
using MobileBank.Persistence.Context;

namespace MobileBank.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MobileBankContext context) : base(context)
        {
        }
        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }
        public async Task<Customer> GetAsync(CancellationToken cancellationToken, int id)
        {
           return await base.GetAsync(cancellationToken, id);
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Customer customer)
        {
             await base.AddAsync(cancellationToken, customer);
        }

        public async Task DeletAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Customer customer)
        {
            await base.UpdateAsync(cancellationToken, customer);
        }

        public async Task<bool> ExistsAsync(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }


    }
}
