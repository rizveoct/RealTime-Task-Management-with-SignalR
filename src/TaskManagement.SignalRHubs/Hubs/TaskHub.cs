using Microsoft.AspNetCore.SignalR;

namespace TaskManagement.SignalRHubs.Hubs;

public sealed class TaskHub : Hub
{
    public async Task JoinBoardAsync(Guid boardId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, GetBoardGroup(boardId));
    }

    public async Task LeaveBoardAsync(Guid boardId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, GetBoardGroup(boardId));
    }

    public Task BroadcastTaskUpdatedAsync(Guid boardId, object payload)
    {
        return Clients.OthersInGroup(GetBoardGroup(boardId)).SendAsync("TaskUpdated", payload);
    }

    private static string GetBoardGroup(Guid boardId) => $"board-{boardId}";
}
