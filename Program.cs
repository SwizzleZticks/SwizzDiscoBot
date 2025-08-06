using Discord.WebSocket;
using SwizzBotDisco.Services;

namespace SwizzBotDisco
{
    // 396069316857954307  - GUILD ID
    // 1287966630738919464 - CHANNEL ID
    // 305044835331735553  - MELLOW ID
    internal class Program
    {
        public static async Task Main()
        {
            await DiscordBotService.StartServiceAsync();

            var nexusModsResponse = await NexusModsService.ValidateServiceAsync();

            if (nexusModsResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Valid Nexus API key!");
            }
            else
            {
                Console.WriteLine($"API validation failed. Status: {nexusModsResponse.StatusCode}");
                return;
            }

            /*
             var trollService = new TrollService(
                DiscordBotService.Client,
                396069316857954307,
                1401734838406348817,
                305044835331735553
            );

            _ = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var latestMod = await NexusModsService.GetLatestModAsync();

                        if (latestMod != null)
                        {
                            await trollService.TrollMellowAsync(latestMod);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERROR] Troll loop failed: {ex.Message}");
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
            */

            await Task.Delay(-1); // keep the app running
        }
    }
}

