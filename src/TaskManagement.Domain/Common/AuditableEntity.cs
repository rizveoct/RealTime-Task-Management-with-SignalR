namespace TaskManagement.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; protected set; }
    public DateTime? ModifiedAtUtc { get; protected set; }
    public Guid? ModifiedBy { get; protected set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAtUtc { get; private set; }
    public Guid? DeletedBy { get; private set; }

    public void MarkCreated(Guid userId)
    {
        CreatedAtUtc = DateTime.UtcNow;
        CreatedBy = userId;
    }

    public void MarkModified(Guid userId)
    {
        ModifiedAtUtc = DateTime.UtcNow;
        ModifiedBy = userId;
    }

    public void SoftDelete(Guid userId)
    {
        if (IsDeleted)
        {
            return;
        }

        IsDeleted = true;
        DeletedAtUtc = DateTime.UtcNow;
        DeletedBy = userId;
    }

    public void Restore()
    {
        IsDeleted = false;
        DeletedAtUtc = null;
        DeletedBy = null;
    }
}
