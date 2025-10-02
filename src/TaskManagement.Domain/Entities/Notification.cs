using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public sealed class Notification : AuditableEntity
{
    internal Notification() { }

    public Notification(Guid recipientId, string title, string message)
    {
        RecipientId = recipientId;
        Title = title;
        Message = message;
    }

    public Guid RecipientId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public bool IsRead { get; private set; }
    public DateTime? ReadAtUtc { get; private set; }

    public void MarkAsRead()
    {
        if (IsRead)
        {
            return;
        }

        IsRead = true;
        ReadAtUtc = DateTime.UtcNow;
    }
}
