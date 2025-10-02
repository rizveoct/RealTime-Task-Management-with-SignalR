using TaskManagement.Domain.Common;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Events;

public sealed class TaskCreatedEvent : IDomainEvent
{
    public TaskCreatedEvent(TaskItem task)
    {
        EventId = Guid.NewGuid();
        Task = task;
        OccurredOnUtc = DateTime.UtcNow;
    }

    public Guid EventId { get; }
    public DateTime OccurredOnUtc { get; }
    public TaskItem Task { get; }
}
