using MediatR;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByBoardId;

public sealed record GetTasksByBoardIdQuery(Guid BoardId) : IRequest<IReadOnlyCollection<TaskDto>>;
