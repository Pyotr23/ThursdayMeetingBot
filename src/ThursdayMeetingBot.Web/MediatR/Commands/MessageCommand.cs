using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.MediatR.Commands
{
    /// <summary>
    ///     Command for processing messages.
    /// </summary>
    public record MessageCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public MessageCommand(Update update) : base(update)
        { }
    }
}