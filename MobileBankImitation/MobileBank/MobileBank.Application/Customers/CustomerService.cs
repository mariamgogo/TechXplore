using Mapster;
using MobileBank.Application.Customers.CustomerExceptions;
using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;

namespace MobileBank.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAllAsync(cancellationToken);
            return result.Adapt<List<CustomerResponseModel>>();
        }

        public async Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _customerRepository.GetAsync(cancellationToken, id);
            if(result == null) throw new CustomerNotFoundException(id.ToString());
            else 
                return result.Adapt<CustomerResponseModel>();
        }
        public async Task CreateAsync(CancellationToken cancellationToken, CustomerRequestPostModel customer)
        {
           // if(await GetAsync(cancellationToken,customer.Id) != null) throw new CustomerAlreadyExistsException(customer.Id.ToString());
            var customerToInsert = customer.Adapt<Customer>();
            await _customerRepository.CreateAsync(cancellationToken, customerToInsert);

        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _customerRepository.ExistsAsyncId(cancellationToken: cancellationToken, id))
                throw new CustomerNotFoundException(id.ToString());

           await _customerRepository.DeletAsync(cancellationToken, id);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, CustomerRequestPutModel customer)
        {
            if (!await _customerRepository.ExistsAsyncId(cancellationToken, customer.Id))
                throw new CustomerNotFoundException(customer.Id.ToString());

            var customerToUpdate = customer.Adapt<Customer>();
            await _customerRepository.UpdateAsync(cancellationToken, customerToUpdate);
        }
    }
}
