using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .Include(t => t.Comments)
            .Include(t => t.Attachments)
            .Include(t => t.Checklist)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task AddAsync(TaskItem task, CancellationToken cancellationToken = default)
    {
        await _context.Tasks.AddAsync(task, cancellationToken);
    }

    public async Task<TaskItem?> GetByIdWithTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .Include(t => t.Comments)
            .Include(t => t.Attachments)
            .Include(t => t.Checklist)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TaskItem>> GetByBoardIdAsync(Guid boardId, CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .Where(t => t.BoardId == boardId)
            .Include(t => t.Comments)
            .Include(t => t.Attachments)
            .Include(t => t.Checklist)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public void Remove(TaskItem task)
    {
        _context.Tasks.Remove(task);
    }
}
