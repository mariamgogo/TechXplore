using MobileBank.Application.Customers;

namespace MobileBank.Application.Bills
{
    public interface IBillService
    {
        Task<List<BillResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<BillResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<BillResponseGetAllModel> GetFullAsync(CancellationToken cancellationToken,int id);
        Task DeletAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, BillRequestModel bill);
        Task UpdateAsync(CancellationToken cancellationToken, BillRequestModel bill);
    }
}
