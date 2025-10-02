using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public sealed class Attachment : AuditableEntity
{
    internal Attachment() { }

    public Attachment(Guid taskId, string fileName, string contentType, string storagePath, long size)
    {
        TaskId = taskId;
        FileName = fileName;
        ContentType = contentType;
        StoragePath = storagePath;
        Size = size;
    }

    public Guid TaskId { get; private set; }
    public string FileName { get; private set; } = string.Empty;
    public string ContentType { get; private set; } = string.Empty;
    public string StoragePath { get; private set; } = string.Empty;
    public long Size { get; private set; }

    public void Rename(string fileName) => FileName = fileName;
}
