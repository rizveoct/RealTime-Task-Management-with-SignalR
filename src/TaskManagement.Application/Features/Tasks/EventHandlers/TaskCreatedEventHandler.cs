using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Common;
using TaskManagement.Domain.Events;

namespace TaskManagement.Application.Features.Tasks.EventHandlers;

public sealed class TaskCreatedEventHandler : INotificationHandler<DomainEventNotification<TaskCreatedEvent>>
{
    private readonly ILogger<TaskCreatedEventHandler> _logger;

    public TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<TaskCreatedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task created with id {TaskId}", notification.DomainEvent.Task.Id);
        return Task.CompletedTask;
    }
}
