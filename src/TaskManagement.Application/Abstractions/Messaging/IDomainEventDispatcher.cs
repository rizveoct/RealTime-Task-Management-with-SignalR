using TaskManagement.Domain.Common;

namespace TaskManagement.Application.Abstractions.Messaging;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
