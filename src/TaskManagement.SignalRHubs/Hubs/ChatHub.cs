using Microsoft.AspNetCore.SignalR;

namespace TaskManagement.SignalRHubs.Hubs;

public sealed class ChatHub : Hub
{
    public Task BroadcastTypingAsync(Guid taskId, Guid userId)
    {
        return Clients.OthersInGroup(GetTaskGroup(taskId)).SendAsync("Typing", new { taskId, userId });
    }

    public Task JoinTaskAsync(Guid taskId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, GetTaskGroup(taskId));
    }

    public Task LeaveTaskAsync(Guid taskId)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, GetTaskGroup(taskId));
    }

    public Task PostMessageAsync(Guid taskId, object payload)
    {
        return Clients.Group(GetTaskGroup(taskId)).SendAsync("MessageReceived", payload);
    }

    private static string GetTaskGroup(Guid taskId) => $"task-{taskId}";
}
