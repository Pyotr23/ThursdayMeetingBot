using ThursdayMeetingBot.Libraries.Core.Interfaces.Bot;

namespace ThursdayMeetingBot.Libraries.MediatR.Handlers
{
    /// <summary>
    ///     Base handler of commands for telegram bot.
    /// </summary>
    public class BotCommandHandler
    {
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