using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Web.Interfaces
{
    /// <summary>
    ///     Service for processing messages received from the bot.
    /// </summary>
    public interface IBotMessageService
    {
        /// <summary>
        ///     Processing a message.
        /// </summary>
        /// <param name="update"> Incoming update. </param>
        Task ProcessAsync(Update update);
    }
}