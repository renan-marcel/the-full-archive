using TheFullArchive.Application.Abstractions.Messaging;
using TheFullArchive.Application.Abstractions.Persistence;
using TheFullArchive.Domain.Archives;

namespace TheFullArchive.Application.Archives.CreateArchive;

public sealed class CreateArchiveHandler : ICommandHandler<CreateArchiveCommand, Guid>
{
    private readonly IArchiveRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateArchiveHandler(IArchiveRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<Guid> Handle(CreateArchiveCommand command, CancellationToken ct)
    {
        var archive = new Archive(command.Title, command.Description);
        await _repo.AddAsync(archive, ct);
        await _uow.SaveChangesAsync(ct);
        return archive.Id;
    }
}

public interface IArchiveRepository : IRepository<Archive> { }
