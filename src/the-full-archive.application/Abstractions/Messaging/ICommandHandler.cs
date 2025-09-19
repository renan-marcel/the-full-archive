namespace TheFullArchive.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand, TResponse>
{
    Task<TResponse> Handle(TCommand command, CancellationToken ct);
}
