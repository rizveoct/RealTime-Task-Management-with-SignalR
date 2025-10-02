using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Messaging;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Events;

namespace TaskManagement.Application.Features.Tasks.Commands.CreateTask;

public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDomainEventDispatcher _eventDispatcher;

    public CreateTaskCommandHandler(
        ITaskRepository taskRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IDomainEventDispatcher eventDispatcher)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem(request.Title, request.Description, request.Priority, request.BoardId);
        task.SetDueDate(request.DueDateUtc);

        await _taskRepository.AddAsync(task, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _eventDispatcher.DispatchAsync(new TaskCreatedEvent(task), cancellationToken);

        return _mapper.Map<TaskDto>(task);
    }
}
