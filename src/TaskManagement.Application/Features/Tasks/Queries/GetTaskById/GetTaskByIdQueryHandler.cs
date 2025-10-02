using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTaskById;

public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTaskByIdQueryHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);
        return task is null ? null : _mapper.Map<TaskDto>(task);
    }
}
