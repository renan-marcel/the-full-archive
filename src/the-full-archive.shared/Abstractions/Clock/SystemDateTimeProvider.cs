namespace TheFullArchive.Shared.Abstractions.Clock;

public sealed class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
