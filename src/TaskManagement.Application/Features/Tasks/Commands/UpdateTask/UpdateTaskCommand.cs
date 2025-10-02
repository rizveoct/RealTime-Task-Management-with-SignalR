using MediatR;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Enumerations;

namespace TaskManagement.Application.Features.Tasks.Commands.UpdateTask;

public sealed class UpdateTaskCommand : IRequest<TaskDto?>
{
    public Guid TaskId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Priority Priority { get; set; } = Priority.Medium;
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public DateTime? DueDateUtc { get; set; }
}
