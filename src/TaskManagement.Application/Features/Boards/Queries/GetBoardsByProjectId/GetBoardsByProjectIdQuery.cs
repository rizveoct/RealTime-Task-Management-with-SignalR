using MediatR;

namespace TaskManagement.Application.Features.Boards.Queries.GetBoardsByProjectId;

public sealed record GetBoardsByProjectIdQuery(Guid ProjectId) : IRequest<IReadOnlyCollection<BoardDetailsDto>>;
