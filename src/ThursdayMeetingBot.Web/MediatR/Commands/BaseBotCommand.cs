using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.MediatR.Commands
{
    /// <summary>
    ///     Base bot command.
    /// </summary>
    public abstract record BaseBotCommand<T> : IRequest<T>
    {
        /// <summary>
        ///     Incoming update.   
        /// </summary>
        public Update Update { get; }

        /// <summary>
        ///     Message.
        /// </summary>
        public Message Message => Update.Message;

        /// <summary>
        ///     Chat.
        /// </summary>
        public Chat Chat => Message.Chat;

        /// <summary>
        ///     Chat identificator.
        /// </summary>
        public long ChatId => Chat.Id;

        /// <summary>
        ///     Sender.
        /// </summary>
        public User Sender => Message.From;

        /// <summary>
        ///     Update's unique identifier.
        /// </summary>
        public int Id => Update.Id;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="update"> Incoming update. </param>
        protected BaseBotCommand(Update update) => Update = update;
    }
}