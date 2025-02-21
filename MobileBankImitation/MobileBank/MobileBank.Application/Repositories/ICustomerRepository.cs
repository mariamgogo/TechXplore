using MobileBank.Application.Customers;
using MobileBank.Domain.Entities;

namespace MobileBank.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Customer> GetAsync(CancellationToken cancellationToken, int id);
        Task DeletAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Customer customer);
        Task UpdateAsync(CancellationToken cancellationToken, Customer customer);
        Task<bool> ExistsAsync(CancellationToken cancellationToken, int id);
    }
}
