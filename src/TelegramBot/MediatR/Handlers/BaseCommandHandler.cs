using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.MediatR.Commands;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Handlers
{
    /// <summary>
    ///     Base handler of commands for telegram bot
    /// </summary>
    public abstract class BaseCommandHandler<T> where T : BaseBotCommand
    {
        /// <summary>
        ///     Logger.
        /// </summary>
        protected readonly ILogger<IRequestHandler<T>> _logger;

        /// <summary>
        ///     Bot service.
        /// </summary>
        protected readonly IBotService _botService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="botService"> Bot service. </param>
        protected BaseCommandHandler(ILogger<IRequestHandler<T>> logger, IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }
    }
}