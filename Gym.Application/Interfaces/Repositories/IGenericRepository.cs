using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gym.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);
        Task<IReadOnlyList<T>> FindAsync(
            System.Linq.Expressions.Expression<Func<T, bool>> predicate,CancellationToken ct); //ef convert to WHERE CLAUSE IN SQL and can combine multiple conditions

        Task AddAsync(T entity , CancellationToken ct);
        void Update(T entity );
        void Remove(T entity );
        public Task<(IReadOnlyList<T> Items, int TotalCount)> GetPagedAsync(
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
      int page,
      int pageSize,
      Expression<Func<T, bool>>? predicate = null,
      CancellationToken ct = default);
    }
}


