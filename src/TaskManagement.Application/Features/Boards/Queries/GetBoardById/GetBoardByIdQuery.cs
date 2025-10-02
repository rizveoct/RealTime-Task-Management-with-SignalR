using MediatR;

namespace TaskManagement.Application.Features.Boards.Queries.GetBoardById;

public sealed record GetBoardByIdQuery(Guid BoardId) : IRequest<BoardDetailsDto?>;
