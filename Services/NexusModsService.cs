using System.Globalization;

namespace SwizzBotDisco.Services;

public class NexusModsService
{
    private static readonly HttpClient _client;
    private static readonly string _baseUrl = "https://api.nexusmods.com/";
    private static readonly string _token = Environment.GetEnvironmentVariable("NEXUS_MODS_API_TOKEN");

    static NexusModsService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(_baseUrl);
        _client.DefaultRequestHeaders.Add("apikey", _token);
        _client.DefaultRequestHeaders.Add("Application-Name", "Swizz Disco Bot");

        Console.WriteLine("Nexus Mods API started.");
    }

    public static async Task<HttpResponseMessage> ValidateServiceAsync()
    {
        var response = await _client.GetAsync("v1/users/validate.json");
        
        return response;
    }
}