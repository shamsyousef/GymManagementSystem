using Gym.Application.Interfaces.Repositories;
using Gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace Gym.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GymDbContext _context;   
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet; // reprsent table in Context
        public GenericRepository(GymDbContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }
        public Task<T?> GetByIdAsync(int id , CancellationToken ct) 
            => _dbSet.FindAsync(id ,ct ).AsTask();
        public async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default)
        {
            return await _dbSet
        .AsNoTracking()
        .ToListAsync(ct);
        }

        public async Task<IReadOnlyList<T>> FindAsync(
          Expression<Func<T, bool>> predicate, CancellationToken ct) //find by condition
        {
            return await _dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(ct);
        }
        public async Task AddAsync(T entity , CancellationToken ct)
        {
            await _dbSet.AddAsync(entity , ct);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity); // Attach the entity to the context if it's not already being tracked
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<(IReadOnlyList<T> Items, int TotalCount)> GetPagedAsync(
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        int page,
        int pageSize,
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken ct = default)
        {
            var query = _dbSet.AsNoTracking();

            if (predicate is not null)
                query = query.Where(predicate);

            var totalCount = await query.CountAsync(ct);

            query = orderBy(query);

            var items = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync(ct);

            return (items.AsReadOnly(), totalCount);
        }


    }
}
