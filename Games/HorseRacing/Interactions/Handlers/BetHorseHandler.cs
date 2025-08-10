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
        public async Task HandleBetSubmit(int horseNumber, ulong ownerId, BettingModal data)
        {
            var horses = RaceManager.CurrentRace;
            if (horses == null || horses.Count == 0 ||
                horseNumber < 1 || horseNumber > horses.Count)
            {
                await RespondAsync("Race ended or that horse is no longer available.", ephemeral: true);
                return;
            }

            var horse = horses[horseNumber - 1];
            await RespondAsync($"Bet {data.Amount} on {horse.Name}", ephemeral: true);
        }

    }
}
