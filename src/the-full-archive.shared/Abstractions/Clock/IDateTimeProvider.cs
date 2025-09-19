namespace TheFullArchive.Shared.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
