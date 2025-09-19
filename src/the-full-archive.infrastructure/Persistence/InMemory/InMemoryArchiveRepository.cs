using TheFullArchive.Application.Abstractions.Persistence;
using TheFullArchive.Application.Archives.CreateArchive;
using TheFullArchive.Domain.Archives;

namespace TheFullArchive.Infrastructure.Persistence.InMemory;

public sealed class InMemoryArchiveRepository : IArchiveRepository
{
    private readonly Dictionary<Guid, Archive> _store = new();

    public Task AddAsync(Archive entity, CancellationToken ct = default)
    {
        _store[entity.Id] = entity;
        return Task.CompletedTask;
    }

    public Task<Archive?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        _store.TryGetValue(id, out var entity);
        return Task.FromResult(entity);
    }
}
