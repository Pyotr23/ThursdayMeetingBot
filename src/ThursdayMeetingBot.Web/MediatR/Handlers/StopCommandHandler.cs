﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Dictionaries;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Command "/stop" handler.
    /// </summary>
    public class StopCommandHandler : BotCommandHandler, IRequestHandler<StopCommand, Unit>
    {
        private readonly ILogger<StopCommandHandler> _logger;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="botService"> Bot service. </param>
        public StopCommandHandler(ILogger<StopCommandHandler> logger,
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
        /// <returns> A task with representation of the void type. </returns>
        public async Task<Unit> Handle(StopCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var chatId = request
                .Chat
                .Id;

            _logger.LogInformation($"[{request.Id}] Handle of stop command");

            await TimerDictionary.DeleteAsync(chatId);

            _logger.LogInformation($"[{request.Id}] Meeting notifications are disabled.");

            await BotService
                .Client
                .SendTextMessageAsync(chatId,
                    BotAnswer.NotificationsAreDisabled,
                    cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}