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

        [ModalInteraction("bet:*:*")]
        public async Task HandleBetSubmit(int horseNumber, ulong ownerId, BettingModal data, Race race)
        {
            var horse = RaceManager.CurrentRace[horseNumber - 1];
            await RespondAsync($"Bet {data.Amount} on horse {horse.Name}", ephemeral: true);
        }
    }
}
