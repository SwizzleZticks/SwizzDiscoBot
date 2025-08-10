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

            int index = 1;
            Race newRace = new Race(new RaceSettings());
            RaceManager.CurrentRace = newRace.Horses;
            var component = new ComponentBuilder();

            foreach (Horse horse in newRace.Horses) 
            {
                component.WithButton(
                    $"{ horse.Name }",     // Label
                    $"bethorse:{ index }", // Custom ID
                    ButtonStyle.Primary    // Style
                    );
                index++;
            }

           var msg = await FollowupAsync("Place your bets!", components: component.Build());
           RaceManager.BetMessageId = msg.Id;
        }
        
    }
}
