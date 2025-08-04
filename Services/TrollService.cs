using Discord;
using Discord.WebSocket;
using SwizzBotDisco.Models;

namespace SwizzBotDisco.Services;

public class TrollService
{
    private readonly DiscordSocketClient _client;
    private readonly ulong _guildId;
    private readonly ulong _channelId;
    private readonly ulong _mellowId;

    public TrollService(DiscordSocketClient client, ulong guildId, ulong channelId, ulong mellowId) 
    {
        _client = client;
        _guildId = guildId;
        _channelId = channelId;
        _mellowId = mellowId;
    }

    public async Task TrollMellowAsync(ModInfo mod)
    {
        var guild = _client.GetGuild(_guildId);
        if (guild == null) return;

        var channel = guild.GetTextChannel(_channelId);
        if (channel == null) return;

        var mention = MentionUtils.MentionUser(_mellowId);
        var modUrl = $"https://www.nexusmods.com/newvegas/mods/{mod.ModId}";

        var message = $"🚨 New mod just dropped for New Vegas: **{mod.Name}**\n" +
                      $"{mention} stop what you're doing and install this trash immediately.\n" +
                      $"{modUrl}";

        await channel.SendMessageAsync(message);
    }
}