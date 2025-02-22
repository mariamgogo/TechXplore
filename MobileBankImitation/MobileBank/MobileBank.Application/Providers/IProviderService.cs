using MobileBank.Application.Customers;

namespace MobileBank.Application.Providers
{
    public interface IProviderService
    {
        Task<List<ProviderResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProviderResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task DeletAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, ProviderRequestPostModel provider);
        Task UpdateAsync(CancellationToken cancellationToken, ProviderRequestPutModel provider);
    }
}
