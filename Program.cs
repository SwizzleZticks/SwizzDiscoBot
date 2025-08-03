using SwizzBotDisco.Services;

namespace SwizzBotDisco
{
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
            }
            
            await Task.Delay(-1);
        }
    }
}
