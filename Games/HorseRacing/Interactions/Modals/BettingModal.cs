using Discord.Interactions;
using System.Runtime;

namespace SwizzBotDisco.Games.HorseRacing.Interactions.Modals
{
    public class BettingModal : IModal
    {
        public string Title => "Horse Bet";

        [InputLabel("Bet Amount")]
        [ModalTextInput("bet", Discord.TextInputStyle.Short, placeholder: "Enter Amount", maxLength: 10)]
        public string Amount { get; set; }
    }
}
