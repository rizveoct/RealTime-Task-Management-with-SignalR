using MediatR;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTaskById;

public sealed record GetTaskByIdQuery(Guid TaskId) : IRequest<TaskDto?>;
