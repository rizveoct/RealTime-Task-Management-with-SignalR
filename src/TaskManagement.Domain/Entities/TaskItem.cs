using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enumerations;
using TaskStatus = TaskManagement.Domain.Enumerations.TaskStatus;


namespace TaskManagement.Domain.Entities;

public sealed class TaskItem : AuditableEntity
{
    private readonly List<Comment> _comments = new();
    private readonly List<Attachment> _attachments = new();
    private readonly List<TaskAssignment> _assignees = new();
    private readonly List<ChecklistItem> _checklist = new();

    internal TaskItem() { }

    public TaskItem(string title, string? description, Priority priority, Guid boardId)
    {
        Title = title;
        Description = description;
        Priority = priority;
        BoardId = boardId;
    }

    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Priority Priority { get; private set; }
    public TaskStatus Status { get; private set; } = TaskStatus.ToDo;
    public DateTime? DueDateUtc { get; private set; }
    public Guid BoardId { get; private set; }
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyCollection<Attachment> Attachments => _attachments.AsReadOnly();
    public IReadOnlyCollection<TaskAssignment> Assignees => _assignees.AsReadOnly();
    public IReadOnlyCollection<ChecklistItem> Checklist => _checklist.AsReadOnly();

    public void UpdateDetails(string title, string? description, Priority priority, TaskStatus status)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
    }

    public void AssignUser(TaskAssignment assignment)
    {
        if (_assignees.Any(a => a.UserId == assignment.UserId))
        {
            return;
        }

        _assignees.Add(assignment);
    }

    public void RemoveAssignee(Guid userId)
    {
        _assignees.RemoveAll(a => a.UserId == userId);
    }

    public void SetDueDate(DateTime? dueDateUtc)
    {
        DueDateUtc = dueDateUtc;
    }

    public Comment AddComment(Guid authorId, string message)
    {
        var comment = new Comment(Id, authorId, message);
        _comments.Add(comment);
        return comment;
    }

    public Attachment AddAttachment(string fileName, string contentType, string storagePath, long size)
    {
        var attachment = new Attachment(Id, fileName, contentType, storagePath, size);
        _attachments.Add(attachment);
        return attachment;
    }

    public ChecklistItem AddChecklistItem(string text)
    {
        var item = new ChecklistItem(text);
        _checklist.Add(item);
        return item;
    }
}

public sealed class ChecklistItem : BaseEntity
{
    internal ChecklistItem() { }

    public ChecklistItem(string text)
    {
        Text = text;
    }

    public string Text { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    public void Toggle(bool completed)
    {
        IsCompleted = completed;
    }
}
