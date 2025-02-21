using Microsoft.Extensions.Logging;
using MobileBank.Application.Accounts;
using MobileBank.Application.Customers;
using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;
using MobileBank.Persistence.Context;

namespace MobileBank.Infrastructure.Repositories
{
    //public class AccountRepository : BaseRepository<Account>, IAccountRepository
    //{
    //    //public AccountRepository(MobileBankContext context) : base(context)
    //    //{
    //    //}
    //    //public Task<List<AccountResponseModel>> GetAllAsync(CancellationToken cancellationToken)
    //    //{
            
    //    //}
    //    //public Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //    //public Task CreateAsync(CancellationToken cancellationToken, CustomerRequestModel person)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public Task DeletAsync(CancellationToken cancellationToken, int id)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}



    //    //public Task UpdateAsync(CancellationToken cancellationToken, CustomerRequestModel person)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}


    //}
}
