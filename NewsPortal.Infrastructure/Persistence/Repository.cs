using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain.Abstractions;

namespace NewsPortal.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _ctx;
    private readonly DbSet<T> _set;
    public Repository(AppDbContext ctx)
    {
        _ctx = ctx;
        _set = _ctx.Set<T>();
    }

    public async Task AddAsync(T entity) => await _set.AddAsync(entity);
    public async Task<T?> GetByIdAsync(object id) => await _set.FindAsync(id);
    public void Remove(T entity) => _set.Remove(entity);
    public void Update(T entity) => _set.Update(entity);
    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) =>
        await _set.FirstOrDefaultAsync(predicate);

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>>? predicate = null) =>
        predicate is null ? await _set.ToListAsync() : await _set.Where(predicate).ToListAsync();
}
