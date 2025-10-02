using TaskManagement.Domain.Enumerations;
using TaskStatus = TaskManagement.Domain.Enumerations.TaskStatus;

namespace TaskManagement.Application.Features.Tasks.Queries;

public sealed record TaskDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public Priority Priority { get; init; }
    public TaskStatus Status { get; init; }
    public DateTime? DueDateUtc { get; init; }
    public Guid BoardId { get; init; }
}
