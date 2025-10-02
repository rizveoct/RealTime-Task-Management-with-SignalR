using MediatR;
using TaskManagement.Application.Abstractions.Messaging;
using TaskManagement.Application.Common;
using TaskManagement.Domain.Common;

namespace TaskManagement.Infrastructure.Messaging;

internal sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
        var notification = (INotification)Activator.CreateInstance(notificationType, domainEvent)!;
        return _mediator.Publish(notification, cancellationToken);
    }
}
