using Microsoft.AspNetCore.SignalR;

namespace TaskManagement.SignalRHubs.Hubs;

public sealed class BoardHub : Hub
{
    public Task BroadcastBoardUpdatedAsync(Guid projectId, object payload)
    {
        return Clients.Group(GetProjectGroup(projectId)).SendAsync("BoardUpdated", payload);
    }

    public Task JoinProjectAsync(Guid projectId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, GetProjectGroup(projectId));
    }

    public Task LeaveProjectAsync(Guid projectId)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, GetProjectGroup(projectId));
    }

    private static string GetProjectGroup(Guid projectId) => $"project-{projectId}";
}
