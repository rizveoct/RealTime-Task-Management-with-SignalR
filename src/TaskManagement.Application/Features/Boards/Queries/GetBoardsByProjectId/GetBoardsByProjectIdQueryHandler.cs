using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Application.Features.Boards.Queries.GetBoardById;

namespace TaskManagement.Application.Features.Boards.Queries.GetBoardsByProjectId;

public sealed class GetBoardsByProjectIdQueryHandler : IRequestHandler<GetBoardsByProjectIdQuery, IReadOnlyCollection<BoardDetailsDto>>
{
    private readonly IBoardRepository _boardRepository;
    private readonly IMapper _mapper;

    public GetBoardsByProjectIdQueryHandler(IBoardRepository boardRepository, IMapper mapper)
    {
        _boardRepository = boardRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<BoardDetailsDto>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
    {
        var boards = await _boardRepository.GetByProjectIdAsync(request.ProjectId, cancellationToken);
        return _mapper.Map<IReadOnlyCollection<BoardDetailsDto>>(boards);
    }
}
