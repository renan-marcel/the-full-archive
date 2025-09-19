using TheFullArchive.Domain.Abstractions;

namespace TheFullArchive.Domain.Archives;

public class Archive : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Archive() { Title = string.Empty; Description = string.Empty; }

    public Archive(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required", nameof(title));
        Title = title.Trim();
        Description = description?.Trim() ?? string.Empty;
    }
}
