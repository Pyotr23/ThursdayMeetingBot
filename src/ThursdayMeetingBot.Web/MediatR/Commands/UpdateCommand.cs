using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.MediatR.Commands
{
    /// <summary>
    ///     Command for handle incoming update.
    /// </summary>
    public record UpdateCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public UpdateCommand(Update update) : base(update) { }
    }
}