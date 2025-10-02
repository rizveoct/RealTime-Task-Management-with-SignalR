using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Persistence;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
