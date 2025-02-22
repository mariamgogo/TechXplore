using Microsoft.EntityFrameworkCore;
using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;
using MobileBank.Persistence.Context;

namespace MobileBank.Infrastructure.Repositories
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(MobileBankContext context) : base(context)
        {
        }
        public async Task<List<Provider>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }
        public async Task<Provider> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, Provider provider)
        {
            await base.AddAsync(cancellationToken, provider);
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, Provider provider)
        {
            await base.UpdateAsync(cancellationToken, provider);
        }

        public async Task DeletAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }
        public async Task<bool> ExistsAsyncIdentifier(CancellationToken cancellationToken, string name)
        {
            return await base.AnyAsync(cancellationToken, x => x.Name == name);
        }

        public async Task<bool> ExistsAsyncId(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }


    }
}
