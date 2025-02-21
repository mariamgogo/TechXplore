namespace MobileBank.Application.Customers
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, CustomerRequestModel customer);
        Task UpdateAsync(CancellationToken cancellationToken, CustomerRequestModel customer);
    }
}
