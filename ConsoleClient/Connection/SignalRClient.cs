using Microsoft.AspNetCore.SignalR.Client;
using static ConsoleClient.ConfigVars;

namespace ConsoleClient.Connection
{
    public class SignalRClient : IConnectionChannelClient
    {
        public HubConnection _playerHubConnection;
        public HubConnection _caveHubConnection;
        
        public SignalRClient(ConfigVars configuration)
        {          
            _playerHubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.BaseUrl + "/playerhub")
                .WithAutomaticReconnect()
                .Build();

            _caveHubConnection = new HubConnectionBuilder()
                .WithUrl(configuration.BaseUrl + "/cavehub")
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task Connect()
        {
            try
            {
                await _playerHubConnection.StartAsync();
                await _caveHubConnection.StartAsync();
                ReceiveMessages();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void ReceiveMessages()
        {
            _caveHubConnection.On<string>("ReceiveWelcomeMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            _caveHubConnection.On<List<string>>("ReceiveAvailableCommands", (commands) =>
            {
                Console.WriteLine("Available commands:");
                int commandNumber = 0;
                foreach (string command in commands)
                {
                    Console.WriteLine($"{commandNumber}: {command}");
                    commandNumber++;
                }
            });
        }
    }
}
