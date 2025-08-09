using SwizzBotDisco.DTOs;
using SwizzBotDisco.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SwizzBotDisco.Services
{
    public class UnbelievaBoatService : IUnbelievaBoatService
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri($"https://unbelievaboat.com/api/v1"),
        };
        private readonly string _token = Environment.GetEnvironmentVariable("UNBELIEVABOAT_KEY")
                                            ?? throw new InvalidOperationException("Missing Unbelievaboat key");
        public UnbelievaBoatService()
        {
            _client.DefaultRequestHeaders.Add("Authorization", _token);
        }


        public async Task<int> GetBalanceAsync(ulong guildId, ulong userId)
        {
            var response = await _client.GetAsync($"guilds/{guildId}/users/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to get balance for user {userId} in guild {guildId}." + $"Status code: {response.StatusCode}");
            }

            var balanceString = await response.Content.ReadAsStringAsync();
            var balanceJson = JsonSerializer.Deserialize<UbBalanceDTO>(balanceString);

            return balanceJson.Cash;
        }

        public async Task<bool> PatchUserBalanceAsync(ulong guildId, ulong userId, int amount, string? reason = null)
        {
            var user = new UbPatchDTO()
            {
                Cash = amount,
                Reason = reason
            };

            string userJson = JsonSerializer.Serialize(user);
            StringContent httpContent = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"guilds/{guildId}/users/{userId}", httpContent);

            return response.IsSuccessStatusCode 
                ? true 
                : throw new HttpRequestException($"Failed to patch balance for user {userId} in guild {guildId}. Status: {response.StatusCode}");
        }
    }
}
