using MobileBank.Domain.Entities;
using System;

namespace MobileBank.Application.Repositories
{
    public interface IBillRepository
    {
        Task<List<Bill>> GetAllAsync(CancellationToken cancellationToken);
        Task<Bill> GetFullAsync(CancellationToken cancellationToken,int id);
        Task<Bill> GetAsync(CancellationToken cancellationToken, int id);
        Task DeletAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Bill bill);
        Task UpdateAsync(CancellationToken cancellationToken, Bill bill);

    }
}
