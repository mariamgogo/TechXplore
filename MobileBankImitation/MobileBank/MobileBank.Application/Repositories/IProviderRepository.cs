using MobileBank.Domain.Entities;

namespace MobileBank.Application.Repositories
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllAsync(CancellationToken cancellationToken);
        Task<Provider> GetAsync(CancellationToken cancellationToken, int id);
        Task DeletAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Provider provider);
        Task UpdateAsync(CancellationToken cancellationToken, Provider provider);
        Task<bool> ExistsAsyncIdentifier(CancellationToken cancellationToken, string name);
        Task<bool> ExistsAsyncId(CancellationToken cancellationToken, int id);

    }
}
