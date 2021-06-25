using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.MediatR.Commands;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler : IRequestHandler<StartCommand, Unit>
    {
        /// <summary>
        ///     Logger.
        /// </summary>
        protected readonly ILogger<IRequestHandler<StartCommand, Unit>> _logger;
        
        /// <inheritdoc />
        public StartCommandHandler(ILogger<IRequestHandler<StartCommand, Unit>> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Handle command.
        /// </summary>
        /// <param name="request"> Command </param>
        /// <returns></returns>
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var chat = request.Chat;

            _logger.LogInformation("{0}Handle begins for chatId={1}.",
                nameof(StartCommand),
                chat.Id);

            return Unit.Value;
        }
    }
}