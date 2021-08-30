using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.MediatR.Commands
{
    /// <summary>
    ///     Command when "/start" received.
    /// </summary>
    public record StartCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public StartCommand(Update update) : base(update)
        {
        }
    }
}