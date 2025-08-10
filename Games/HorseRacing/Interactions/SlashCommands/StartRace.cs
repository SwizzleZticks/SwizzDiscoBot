using Discord;
using Discord.Interactions;
using SwizzBotDisco.Games.HorseRacing.Models;

namespace SwizzBotDisco.Games.HorseRacing.Interactions.SlashCommands
{
    public class StartRace : InteractionModuleBase<SocketInteractionContext>
    {
        [EnabledInDm(false)]
        [SlashCommand("start-race", "Begin betting phase for horse race")]
        public async Task HandleStartRaceCommand()
        {
            await DeferAsync();

            var race = new Race(new RaceSettings());
            var component = new ComponentBuilder();
            int horseId = 1;
            foreach (var h in race.Horses)
            {
                race.Horses[horseId] = h;
                component.WithButton(h.Name, $"bethorse:{horseId}", ButtonStyle.Primary);
                horseId++;
            }
            var msg = await FollowupAsync("Place your bets!", components: component.Build());
            RaceManager.Races[msg.Id] = race;
            RaceManager.BettingOpen = true;
        }
        
    }
}
