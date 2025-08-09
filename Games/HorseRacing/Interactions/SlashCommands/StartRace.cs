using Discord;
using Discord.Interactions;
using SwizzBotDisco.Games.HorseRacing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwizzBotDisco.Games.HorseRacing.Interactions.SlashCommands
{
    public class StartRace : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("start-race", "Begin betting for race")]
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
