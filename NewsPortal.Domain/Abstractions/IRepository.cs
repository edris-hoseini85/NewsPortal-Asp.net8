using System.Linq.Expressions;

namespace NewsPortal.Domain.Abstractions;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object id);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
