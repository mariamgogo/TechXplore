using Microsoft.Extensions.Logging;
using MobileBank.Application.Repositories;
using MobileBank.Persistence.Context;
using System.Transactions;

namespace MobileBank.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(MobileBankContext context) : base(context)
        {
        }
    }
}
