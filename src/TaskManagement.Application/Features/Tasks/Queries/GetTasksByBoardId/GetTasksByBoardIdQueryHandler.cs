using System;
using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasksByBoardId;

public sealed class GetTasksByBoardIdQueryHandler : IRequestHandler<GetTasksByBoardIdQuery, IReadOnlyCollection<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTasksByBoardIdQueryHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<TaskDto>> Handle(GetTasksByBoardIdQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetByBoardIdAsync(request.BoardId, cancellationToken);
        return tasks.Count == 0
            ? Array.Empty<TaskDto>()
            : _mapper.Map<IReadOnlyCollection<TaskDto>>(tasks);
    }
}
