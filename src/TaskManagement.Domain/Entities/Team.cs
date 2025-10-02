using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public sealed class Team : AuditableEntity
{
    private readonly List<Guid> _memberIds = new();

    private Team() { }

    public Team(string name, Guid projectId)
    {
        Name = name;
        ProjectId = projectId;
    }

    public string Name { get; private set; } = string.Empty;
    public Guid ProjectId { get; private set; }
    public IReadOnlyCollection<Guid> MemberIds => _memberIds.AsReadOnly();

    public void Rename(string name) => Name = name;

    public void AddMember(Guid userId)
    {
        if (!_memberIds.Contains(userId))
        {
            _memberIds.Add(userId);
        }
    }

    public void RemoveMember(Guid userId) => _memberIds.Remove(userId);
}
