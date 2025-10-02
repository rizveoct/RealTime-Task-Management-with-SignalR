using Microsoft.AspNetCore.SignalR;

namespace TaskManagement.SignalRHubs.Hubs;

public sealed class NotificationHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Connected", DateTime.UtcNow);
    }

    public Task SendNotificationAsync(Guid recipientId, object payload)
    {
        return Clients.User(recipientId.ToString()).SendAsync("NotificationReceived", payload);
    }
}
