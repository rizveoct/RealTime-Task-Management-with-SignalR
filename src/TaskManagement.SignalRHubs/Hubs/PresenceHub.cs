using Microsoft.AspNetCore.SignalR;

namespace TaskManagement.SignalRHubs.Hubs;

public sealed class PresenceHub : Hub
{
    private static readonly HashSet<string> OnlineUsers = new();
    private static readonly object SyncRoot = new();

    public override async Task OnConnectedAsync()
    {
        lock (SyncRoot)
        {
            OnlineUsers.Add(Context.UserIdentifier ?? Context.ConnectionId);
        }

        await Clients.All.SendAsync("PresenceChanged", OnlineUsers.ToArray());
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        lock (SyncRoot)
        {
            OnlineUsers.Remove(Context.UserIdentifier ?? Context.ConnectionId);
        }

        await Clients.All.SendAsync("PresenceChanged", OnlineUsers.ToArray());
        await base.OnDisconnectedAsync(exception);
    }
}
