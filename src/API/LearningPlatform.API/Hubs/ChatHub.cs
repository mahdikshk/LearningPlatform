using LearningPlatform.Application.Contracts.Identity;
using Microsoft.AspNetCore.SignalR;

namespace LearningPlatform.API.Hubs;

public class ChatHub : Hub
{
    private readonly IRoleService _roleService;

    public ChatHub(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}
