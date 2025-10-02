using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.Application.Features.Tasks.Commands.UpdateTask;

public sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto?>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TaskDto?> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdWithTrackingAsync(request.TaskId, cancellationToken);
        if (task is null)
        {
            return null;
        }

        task.UpdateDetails(request.Title, request.Description, request.Priority, request.Status);
        task.SetDueDate(request.DueDateUtc);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TaskDto>(task);
    }
}
