using Mapster;
using MobileBank.Application.Repositories;
using MobileBank.Application.Providers.ProviderExceptions;
using MobileBank.Domain.Entities;
using MobileBank.Application.Customers.CustomerExceptions;

namespace MobileBank.Application.Providers
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<List<ProviderResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {   var result = await _providerRepository.GetAllAsync(cancellationToken);
            return result.Adapt<List<ProviderResponseModel>>();
        }

        public async Task<ProviderResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {

            var result = await _providerRepository.GetAsync(cancellationToken, id);
            if (result == null) throw new ProviderNotFoundException(id.ToString());
            else
                return result.Adapt<ProviderResponseModel>();
        }
        public async Task CreateAsync(CancellationToken cancellationToken, ProviderRequestModel provider)
        {
            //if (await GetAsync(cancellationToken, provider.Id) != null) throw new ProviderAlreadyExistsException(provider.Id.ToString());
            var providerToInsert = provider.Adapt<Provider>();
            await _providerRepository.CreateAsync(cancellationToken, providerToInsert);
        }

        public async Task DeletAsync(CancellationToken cancellationToken, int id)
        {
            if (await GetAsync(cancellationToken, id) == null) throw new ProviderNotFoundException(id.ToString());

            await _providerRepository.DeletAsync(cancellationToken, id);
        }


        public async Task UpdateAsync(CancellationToken cancellationToken, ProviderRequestModel provider)
        {
            if (!await _providerRepository.ExistsAsyncIdentifier(cancellationToken, provider.Name))
                throw new ProviderNotFoundException(provider.Name);
            var providerToUpdate = provider.Adapt<Provider>();
            await _providerRepository.UpdateAsync(cancellationToken, providerToUpdate);
        }
    }
}
