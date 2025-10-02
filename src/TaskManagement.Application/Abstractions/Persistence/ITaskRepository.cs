using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Persistence;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(TaskItem task, CancellationToken cancellationToken = default);
}
