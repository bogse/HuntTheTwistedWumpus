using GameServer.Caverns;
using GameServer.Commands;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace GameServer.Hubs
{
    [SignalRHub]
    public class CaveHub : Hub
    {
        public async Task SendCavernSound(ICommand command, Room room)
        {
            command.Execute(room);

            await Clients.All.SendAsync("ReceiveSound", command);
        }

        public override async Task OnConnectedAsync()
        {
            var welcomeMessage = "Welcome to the game!";
            var commands = new List<string> { "Exit", "WalkToCommand" };

            await Clients.Caller.SendAsync("ReceiveWelcomeMessage", welcomeMessage);
            await Clients.Caller.SendAsync("ReceiveAvailableCommands", commands);

            await base.OnConnectedAsync();
        }
    }
}
