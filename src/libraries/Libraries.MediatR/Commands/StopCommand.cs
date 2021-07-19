using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Command when "/start" received.
    /// </summary>
    public record StopCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public StopCommand(Message message) : base(message) 
        {}
    }
}