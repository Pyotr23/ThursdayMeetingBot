using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.TelegramBot.Dictionaries;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.MediatR.Commands;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Handlers
{
    /// <summary>
    ///     Command "/stop" handler.
    /// </summary>
    public class StopCommandHandler : BotCommandHandler, IRequestHandler<StopCommand, Unit>
    {
        private readonly ILogger<StartCommandHandler> _logger;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="botService"> Bot service. </param>
        public StopCommandHandler(ILogger<StartCommandHandler> logger,
            IBotService botService)
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
        public async Task<Unit> Handle(StopCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var chatId = request
                .Chat
                .Id;

            _logger.LogInformation("{0}Handle begins for chatId={1}.",
                nameof(StopCommand),
                chatId);

            await TimerDictionary.DeleteAsync(chatId);

            var responseText = "Уведомления о встречах отключены.";
            
            _logger.LogInformation(responseText);

            await BotService
                .Client
                .SendTextMessageAsync(chatId,
                    responseText,
                    cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}