using Discord.Interactions;
using Discord.WebSocket;
using SwizzBotDisco.Services;
using System.Reflection;

namespace SwizzBotDisco
{
    // 396069316857954307  - GUILD ID
    internal class Program
    {
        public static async Task Main()
        {
            await DiscordBotService.StartServiceAsync();
            var client = DiscordBotService.Client;


            var service = new InteractionService(client);

            client.Log += msg =>
            {
                Console.WriteLine($"[Client] {msg}");
                return Task.CompletedTask;
            };

            service.Log += msg =>
            {
                Console.WriteLine($"[InteractionService] {msg}");
                return Task.CompletedTask;
            };

            service.SlashCommandExecuted += async (cmd, ctx, result) =>
            {
                if (!result.IsSuccess)
                    Console.WriteLine($"[SlashCommand Error] {result.Error} | {result.ErrorReason}");
            };



            await service.AddModulesAsync(Assembly.GetExecutingAssembly(), services: null);

            client.InteractionCreated += async interaction =>
            {
                var ctx = new SocketInteractionContext(client, interaction);
                await service.ExecuteCommandAsync(ctx, services: null);
            };

            client.Ready += async () =>
            {
                ulong devGuildId = 396069316857954307;
                await service.RegisterCommandsToGuildAsync(devGuildId);
            };

            await Task.Delay(-1);
        }
    }
}

