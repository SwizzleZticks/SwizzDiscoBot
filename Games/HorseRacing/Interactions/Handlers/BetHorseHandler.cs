using Discord.Interactions;
using SwizzBotDisco.Games.HorseRacing.Interactions.Modals;
using SwizzBotDisco.Services;


namespace SwizzBotDisco.Games.HorseRacing.Interactions.Handlers
{
    public class BetHorseHandler : InteractionModuleBase<SocketInteractionContext>
    {
        [ComponentInteraction("bethorse:*")]
        public async Task HandleBetHorseInput(int horseNumber)
        {
            var ubService = new UnbelievaBoatService();
            int cash = await ubService.GetBalanceAsync(Context.Guild.Id, Context.User.Id);
        }
    }
}
