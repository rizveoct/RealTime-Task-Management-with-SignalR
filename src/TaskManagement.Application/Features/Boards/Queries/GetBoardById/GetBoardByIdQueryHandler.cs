using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;

namespace TaskManagement.Application.Features.Boards.Queries.GetBoardById;

public sealed class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, BoardDetailsDto?>
{
    private readonly IBoardRepository _boardRepository;
    private readonly IMapper _mapper;

    public GetBoardByIdQueryHandler(IBoardRepository boardRepository, IMapper mapper)
    {
        _boardRepository = boardRepository;
        _mapper = mapper;
    }

    public async Task<BoardDetailsDto?> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
    {
        var board = await _boardRepository.GetByIdAsync(request.BoardId, cancellationToken);
        return board is null ? null : _mapper.Map<BoardDetailsDto>(board);
    }
}
