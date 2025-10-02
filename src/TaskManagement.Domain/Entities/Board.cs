using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enumerations;

namespace TaskManagement.Domain.Entities;

public sealed class Board : AuditableEntity
{
    private readonly List<TaskItem> _tasks = new();

    internal Board() { }

    public Board(string name, Guid projectId, int order)
    {
        Name = name;
        ProjectId = projectId;
        Order = order;
    }

    public string Name { get; private set; } = string.Empty;
    public string? Description { get; internal set; }
    public Guid ProjectId { get; private set; }
    public int Order { get; private set; }
    public bool IsArchived { get; private set; }
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    public void Rename(string name) => Name = name;

    public void Reorder(int order) => Order = order;

    public TaskItem CreateTask(string title, string? description, Priority priority)
    {
        var task = new TaskItem(title, description, priority, Id);
        _tasks.Add(task);
        return task;
    }

    public void Archive() => IsArchived = true;

    public void Restore() => IsArchived = false;
}
