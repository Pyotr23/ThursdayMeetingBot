using Telegram.Bot.Types;
using ThursdayMeetingBot.TelegramBot.Interfaces;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Handlers
{
    /// <summary>
    ///     Base handler of commands for telegram bot.
    /// </summary>
    public class BotCommandHandler
    {
        /// <summary>
        ///     Bot chat.
        /// </summary>
        protected Chat? Chat { get; set; }
        
        /// <summary>
        ///     Bot service
        /// </summary>
        protected IBotService BotService { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="botService"> Bot service. </param>
        protected BotCommandHandler(IBotService botService)
        {
            BotService = botService;
        }
    }
}