using TheFullArchive.Domain.Abstractions;

namespace TheFullArchive.Application.Abstractions.Persistence;

public interface IRepository<T> where T : IAggregateRoot
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
}
