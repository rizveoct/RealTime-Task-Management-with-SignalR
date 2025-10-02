using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enumerations;

namespace TaskManagement.Domain.Entities;

public sealed class User : AuditableEntity
{
    private readonly List<UserRole> _roles = new();
    private readonly List<ProjectMembership> _projects = new();
    private readonly List<TaskAssignment> _tasks = new();

    private User() { }

    public User(string email, string firstName, string lastName)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public bool EmailConfirmed { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public DateTimeOffset? LockoutEnd { get; private set; }
    public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd.Value.UtcDateTime > DateTime.UtcNow;

    public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();
    public IReadOnlyCollection<ProjectMembership> Projects => _projects.AsReadOnly();
    public IReadOnlyCollection<TaskAssignment> Tasks => _tasks.AsReadOnly();

    public string FullName => $"{FirstName} {LastName}".Trim();

    public void SetPasswordHash(string hash) => PasswordHash = hash;

    public void ConfirmEmail() => EmailConfirmed = true;

    public void EnableTwoFactor() => TwoFactorEnabled = true;

    public void DisableTwoFactor() => TwoFactorEnabled = false;

    public void AddRole(UserRole role)
    {
        if (!_roles.Contains(role))
        {
            _roles.Add(role);
        }
    }

    public void RemoveRole(UserRole role) => _roles.Remove(role);

    public void AddProject(Project project, UserRole role)
    {
        if (_projects.Any(p => p.ProjectId == project.Id))
        {
            return;
        }

        var membership = new ProjectMembership(Id, project.Id, role);
        _projects.Add(membership);
        project.AddMember(membership);
    }

    public void AssignTask(TaskItem task)
    {
        if (_tasks.Any(t => t.TaskId == task.Id))
        {
            return;
        }

        var assignment = new TaskAssignment(Id, task.Id);
        _tasks.Add(assignment);
        task.AssignUser(assignment);
    }

    public void LockUntil(DateTimeOffset lockoutEnd) => LockoutEnd = lockoutEnd;

    public void Unlock()
    {
        LockoutEnd = null;
    }
}

public sealed record ProjectMembership(Guid UserId, Guid ProjectId, UserRole Role);

public sealed record TaskAssignment(Guid UserId, Guid TaskId);
