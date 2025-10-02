using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public sealed class Comment : AuditableEntity
{
    internal Comment() { }

    public Comment(Guid taskId, Guid authorId, string message)
    {
        TaskId = taskId;
        AuthorId = authorId;
        Message = message;
    }

    public Guid TaskId { get; private set; }
    public Guid AuthorId { get; private set; }
    public string Message { get; private set; } = string.Empty;

    public void UpdateMessage(string message)
    {
        Message = message;
    }
}
