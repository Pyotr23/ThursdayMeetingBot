using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Commands
{
    /// <summary>
    ///     Base bot command.
    /// </summary>
    public abstract record BaseBotCommand<T> : IRequest<T>
    {
        /// <summary>
        ///     Message.
        /// </summary>
        private Message Message { get; }

        /// <summary>
        ///     Chat.
        /// </summary>
        public Chat Chat => Message.Chat;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="message"> Message. </param>
        protected BaseBotCommand(Message message) => Message = message;
    }
}