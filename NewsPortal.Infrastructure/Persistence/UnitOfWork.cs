using System.Threading;
using System.Threading.Tasks;
using NewsPortal.Domain.Abstractions;

namespace NewsPortal.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _ctx;
    public UnitOfWork(AppDbContext ctx) => _ctx = ctx;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _ctx.SaveChangesAsync(cancellationToken);
}
