using Mapster;
using MobileBank.Application.Bills.BillExceptions;
using MobileBank.Application.Customers.CustomerExceptions;
using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;

namespace MobileBank.Application.Bills
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<List<BillResponseGetAllModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _billRepository.GetAllAsync(cancellationToken);

            return result.Select(bill => new BillResponseGetAllModel
            {
                Amount = bill.Amount,
                ProviderId = bill.ProviderId,
                ProviderName = bill.Provider?.Name,
                ProviderLogo = bill.Provider?.LogoLink,
                CustomerId = bill.CustomerId,
                CustomerFullName = $"{bill.Customer?.FirstName} {bill.Customer?.LastName}"
            }).ToList();
        }


        public async Task<BillResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _billRepository.GetAsync(cancellationToken, id);
            if (result == null) throw new BillNotFoundException(id.ToString());
            else
                return result.Adapt<BillResponseModel>();
        }

        public async Task<BillResponseGetAllModel> GetFullAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _billRepository.GetFullAsync(cancellationToken, id);
            if (result == null) throw new BillNotFoundException(id.ToString());
            else
                return new BillResponseGetAllModel
                {
                    Amount = result.Amount,
                    ProviderId = result.ProviderId,
                    ProviderName = result.Provider?.Name,
                    ProviderLogo = result.Provider?.LogoLink,
                    CustomerId = result.CustomerId,
                    CustomerFullName = result.Customer?.FirstName + " " + result.Customer?.LastName
                };
        }
        public async Task CreateAsync(CancellationToken cancellationToken, BillRequestModel bill)
        {
            if (await GetAsync(cancellationToken, bill.Id) != null) throw new BillAlreadyExistsException(bill.Id.ToString());
            var billToInsert = bill.Adapt<Bill>();
            await _billRepository.CreateAsync(cancellationToken, billToInsert);
        }


        public async Task UpdateAsync(CancellationToken cancellationToken, BillRequestModel bill)
        {
            if (await GetAsync(cancellationToken, bill.Id) == null) throw new BillNotFoundException(bill.Id.ToString());

            var billToUpdate = bill.Adapt<Bill>();
            await _billRepository.UpdateAsync(cancellationToken, billToUpdate);
        }
        public async Task DeletAsync(CancellationToken cancellationToken, int id)
        {
            if (await GetAsync(cancellationToken, id) == null) throw new BillNotFoundException(id.ToString());

            await _billRepository.DeletAsync(cancellationToken, id);
        }

    }
}
