using Discord.Interactions;
using SwizzBotDisco.Games.HorseRacing.Interactions.Modals;
using SwizzBotDisco.Games.HorseRacing.Models;
using SwizzBotDisco.Services;


namespace SwizzBotDisco.Games.HorseRacing.Interactions.Handlers
{
    public class BetHorseHandler : InteractionModuleBase<SocketInteractionContext>
    {
        [ComponentInteraction("bethorse:*")]
        public async Task HandleBetHorseInput(int horseNumber)
        {
            await RespondWithModalAsync<BettingModal>($"bet:{horseNumber}:{Context.User.Id}");
        }

        [ModalInteraction("bet:*:*:*")]
        public async Task HandleBetSubmit(ulong raceId, int horseId, ulong ownerId, BettingModal data)
        {
            if (ownerId != Context.User.Id)
            {
                await RespondAsync("This modal isn’t yours.", ephemeral: true);
                return;
            }

            if (!RaceManager.BettingOpen || !RaceManager.Races.TryGetValue(raceId, out var race))
            {
                await RespondAsync("Race ended or not found.", ephemeral: true);
                return;
            }

            if (horseId < 1 || horseId > race.Horses.Count)
            {
                await RespondAsync("Horse not found.", ephemeral: true);
                return;
            }

            var horse = race.Horses[horseId - 1];
            await RespondAsync($"Bet {data.Amount} on **{horse.Name}**", ephemeral: true);
        }

    }
}
