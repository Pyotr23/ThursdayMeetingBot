using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.MediatR.Commands;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler : BotCommandHandler, IRequestHandler<StartCommand, Unit>
    {
        private readonly ILogger<StartCommandHandler> _logger;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="botService"> Bot service. </param>
        /// <param name="logger"> Logger. </param>
        public StartCommandHandler(ILogger<StartCommandHandler> logger, IBotService botService)
            : base(botService)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Handle command.
        /// </summary>
        /// <param name="request"> Command. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns></returns>
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            Chat = request.Chat;

            _logger.LogInformation("{0}Handle begins for chatId={1}.",
                nameof(StartCommand),
                Chat.Id);

            return Unit.Value;
        }
    }
}