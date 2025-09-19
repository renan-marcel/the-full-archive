using TheFullArchive.Application.Abstractions.Messaging;

namespace TheFullArchive.Application.Archives.CreateArchive;

public sealed record CreateArchiveCommand(string Title, string Description) : ICommand<Guid>;
