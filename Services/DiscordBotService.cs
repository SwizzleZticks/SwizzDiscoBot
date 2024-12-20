using Discord.WebSocket;
using Discord;
using SwizzBotDisco.Config;

namespace SwizzBotDisco.Services
{
    public class DiscordBotService
    {
        private static DiscordSocketClient _client;

        public static async Task StartServiceAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            string token = await JSONReader.GetTokenAsync();

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg) //Create logging service later and move
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
