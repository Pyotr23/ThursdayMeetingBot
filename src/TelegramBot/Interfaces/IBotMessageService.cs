using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.TelegramBot.Interfaces
{
    /// <summary>
    ///     Service for processing messages received from the bot.
    /// </summary>
    public interface IBotMessageService
    {
        /// <summary>
        ///     Processing a message.
        /// </summary>
        /// <param name="messageEntity"> New message. </param>
        Task ProcessAsync(Update messageEntity);
    }
}