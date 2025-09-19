namespace TheFullArchive.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> { }
public interface ICommand : ICommand<Unit> { }
public readonly record struct Unit;
