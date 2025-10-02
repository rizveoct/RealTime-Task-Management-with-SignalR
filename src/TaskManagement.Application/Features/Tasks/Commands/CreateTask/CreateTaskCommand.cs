using MediatR;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Enumerations;

namespace TaskManagement.Application.Features.Tasks.Commands.CreateTask;

public sealed record CreateTaskCommand(
    Guid BoardId,
    string Title,
    string? Description,
    Priority Priority,
    DateTime? DueDateUtc) : IRequest<TaskDto>;
