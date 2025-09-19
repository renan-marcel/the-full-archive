using TheFullArchive.Application.Abstractions.Persistence;

namespace TheFullArchive.Infrastructure.Persistence.InMemory;

public sealed class InMemoryUnitOfWork : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => Task.FromResult(0);
}
