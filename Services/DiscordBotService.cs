using Discord.WebSocket;
using Discord;

namespace SwizzBotDisco.Services
{
    public static class DiscordBotService
    {
        private static DiscordSocketClient? _client;

        public static async Task StartServiceAsync()
        {
            string? token = Environment.GetEnvironmentVariable("BOT_TOKEN");
            
            _client = new DiscordSocketClient();
            _client.Log += Log;
            

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        private static Task Log(LogMessage msg) //Create logging service later and move
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
