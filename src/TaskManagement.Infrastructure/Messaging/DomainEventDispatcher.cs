using MediatR;
using TaskManagement.Application.Abstractions.Messaging;
using TaskManagement.Application.Common;
using TaskManagement.Domain.Common;

namespace TaskManagement.Infrastructure.Messaging;

internal sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IPublisher _publisher;

    public DomainEventDispatcher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
        var notification = Activator.CreateInstance(notificationType, domainEvent);

        return _publisher.Publish((INotification)notification!, cancellationToken);
    }
}
