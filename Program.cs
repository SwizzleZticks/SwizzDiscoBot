using SwizzBotDisco.Services;

namespace SwizzBotDisco
{
    internal class Program
    {
        public static async Task Main()
        {
            await DiscordBotService.StartServiceAsync();
        }
    }
}
