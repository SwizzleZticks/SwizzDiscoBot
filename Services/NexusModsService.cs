using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using SwizzBotDisco.Models;

namespace SwizzBotDisco.Services;

public static class NexusModsService
{
    private static readonly HttpClient _client;
    private static readonly string _baseUrl = "https://api.nexusmods.com/";
    private static readonly string _token = Environment.GetEnvironmentVariable("NEXUS_MODS_API_TOKEN");
    private static ModInfo _latestMod;

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

    public static async Task<ModInfo> GetLatestModAsync()
    {
        var reponse = await _client.GetAsync("v1/games/newvegas/mods/latest_added.json");
        var latestModJson = await reponse.Content.ReadAsStreamAsync();
        var mods = await JsonSerializer.DeserializeAsync<List<ModInfo>>(latestModJson);

        if (mods == null || mods.Count == 0)
        {
            return null;
        }
        if (_latestMod != null && mods[0].ModId == _latestMod.ModId)
        {
            return null;
        }
        
        _latestMod = mods[0];
        
        return mods[0];
    }
}