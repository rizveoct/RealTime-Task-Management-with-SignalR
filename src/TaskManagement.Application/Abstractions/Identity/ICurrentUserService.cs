namespace TaskManagement.Application.Abstractions.Identity;

public interface ICurrentUserService
{
    Guid UserId { get; }
    bool IsAuthenticated { get; }
}
