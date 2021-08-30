using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.MediatR.Commands
{
    /// <summary>
    ///     Command when "/start" received.
    /// </summary>
    public record StopCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public StopCommand(Update update) : base(update) 
        {}
    }
}