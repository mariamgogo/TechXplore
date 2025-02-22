using Microsoft.EntityFrameworkCore;
using MobileBank.Application.Repositories;
using MobileBank.Domain.Entities;
using MobileBank.Persistence.Context;

namespace MobileBank.Infrastructure.Repositories
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(MobileBankContext context) : base(context)
        {
        }
        public async Task<List<Bill>> GetAllAsync(CancellationToken cancellationToken)
        {
              return await _dbSet
                .Include(b => b.Provider)
                .Include(b => b.Customer)
                .ToListAsync(cancellationToken);
        }
        public async Task<Bill> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }


        public async Task<Bill?> GetFullAsync(CancellationToken cancellationToken, int id)
        {

            return await _dbSet
                .Include(b => b.Provider)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        }

        public async Task CreateAsync(CancellationToken cancellationToken, Bill bill)
        {
            await base.AddAsync(cancellationToken, bill);
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, Bill bill)
        {
            await base.UpdateAsync(cancellationToken, bill);
        }

        public async Task DeletAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }


    }
}
