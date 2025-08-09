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
            int index = 1;
            Race newRace = new Race(new RaceSettings());
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

            await RespondAsync("Place your bets!", components: component.Build());
        }
        
    }
}
