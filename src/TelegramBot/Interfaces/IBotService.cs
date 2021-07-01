using Telegram.Bot;

namespace ThursdayMeetingBot.TelegramBot.Interfaces
{
    /// <summary>
    ///     Service for managing telegram bot client.
    /// </summary>
    public interface IBotService
    {
        /// <summary>
        ///     Telegram bot client.
        /// </summary>
        public TelegramBotClient Client { get; }
    }
}