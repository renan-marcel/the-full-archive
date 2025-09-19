using TheFullArchive.shared.Abstractions;

namespace TheFullArchive.Domain.Archives;

public class Archive : Entity<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Archive(Guid id, string title, string description) : base(id)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required", nameof(title));
        Title = title.Trim();
        Description = description?.Trim() ?? string.Empty;
    }
}
