using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManagement.Application.Abstractions.Persistence;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Repositories;

internal sealed class BoardRepository : IBoardRepository
{
    private readonly AppDbContext _context;

    public BoardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Board?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Boards
            .Include(b => b.Tasks)
            .ThenInclude(t => t.Comments)
            .Include(b => b.Tasks)
            .ThenInclude(t => t.Attachments)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Board>> GetByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        return await _context.Boards
            .Where(b => b.ProjectId == projectId)
            .Include(b => b.Tasks)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
