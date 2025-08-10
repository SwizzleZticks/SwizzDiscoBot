using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;

namespace SwizzBotDisco.Services
{
    public static class DiscordBotService
    {
        private static DiscordSocketClient? _client;

        public static async Task StartServiceAsync()
        {
            string? token = Environment.GetEnvironmentVariable("BOT_TOKEN");

            _client = new DiscordSocketClient();
            var interactionService = new InteractionService(_client);

            _client.Log += Log;


            _client.InteractionCreated += async interaction =>
            {
                var ctx = new SocketInteractionContext(_client, interaction);
                await interactionService.ExecuteCommandAsync(ctx, null);
            };

            await interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }


        public static DiscordSocketClient Client => _client;

        private static Task Log(LogMessage msg) //Create logging service later and move
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
