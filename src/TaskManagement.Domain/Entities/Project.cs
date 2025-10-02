using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enumerations;

namespace TaskManagement.Domain.Entities;

public sealed class Project : AuditableEntity
{
    private readonly List<Board> _boards = new();
    private readonly List<ProjectMembership> _members = new();

    private Project() { }

    public Project(string name, Guid organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
    }

    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Guid OrganizationId { get; private set; }
    public IReadOnlyCollection<Board> Boards => _boards.AsReadOnly();
    public IReadOnlyCollection<ProjectMembership> Members => _members.AsReadOnly();

    public void UpdateDetails(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public Board CreateBoard(string name, string? description, int order)
    {
        var board = new Board(name, Id, order)
        {
            Description = description
        };

        _boards.Add(board);
        return board;
    }

    public void AddMember(ProjectMembership membership)
    {
        if (_members.Any(m => m.UserId == membership.UserId))
        {
            return;
        }

        _members.Add(membership);
    }

    public bool HasPermission(Guid userId, UserRole minimumRole)
    {
        var membership = _members.FirstOrDefault(m => m.UserId == userId);
        if (membership is null)
        {
            return false;
        }

        return membership.Role <= minimumRole;
    }
}
