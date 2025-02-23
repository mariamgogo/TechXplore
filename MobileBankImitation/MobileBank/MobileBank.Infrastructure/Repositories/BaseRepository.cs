﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace MobileBank.Infrastructure.Repositories
{
    public class BaseRepository<T> where T : class
    {

        protected readonly DbContext _context;

        protected readonly DbSet<T> _dbSet;


        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task<T?> GetAsync(CancellationToken token, params object[] key)
        {
            return await _dbSet.FindAsync(key, token);
        }

        public async Task AddAsync(CancellationToken token, T entity)
        {
            await _dbSet.AddAsync(entity, token);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(CancellationToken token, T entity)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(CancellationToken token, params object[] key)
        {
            var entity = await GetAsync(token, key);
            if (entity == null) return;
            _dbSet.Remove(entity);
            await SaveChangesAsync(token);
        }
        public async Task<bool> AnyAsync(CancellationToken token, Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate, token);
        }


        private async Task SaveChangesAsync(CancellationToken token)
        {
            try
            {
                await _context.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
