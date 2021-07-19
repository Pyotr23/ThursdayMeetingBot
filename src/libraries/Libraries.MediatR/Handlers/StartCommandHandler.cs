﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.Libraries.Core.Configurations;
using ThursdayMeetingBot.Libraries.Core.Helpers;
using ThursdayMeetingBot.Libraries.Core.Interfaces.Bot;
using ThursdayMeetingBot.Libraries.MediatR.Commands;
using ThursdayMeetingBot.Libraries.MediatR.Constants;
using ThursdayMeetingBot.Libraries.MediatR.Dictionaries;

namespace ThursdayMeetingBot.Libraries.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler : BotCommandHandler, IRequestHandler<StartCommand, Unit>
    {
        private readonly ILogger<StartCommandHandler> _logger;
        private readonly DateTimeHelper _dateTimeHelper;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="notificationConfigurationOptions"> Notification settings from appsettings. </param>
        /// <param name="botService"> Bot service. </param>
        public StartCommandHandler(ILogger<StartCommandHandler> logger,
            IOptions<NotificationConfiguration> notificationConfigurationOptions, 
            IBotService botService)
            : base(botService)
        {
            _logger = logger;
            _dateTimeHelper = new DateTimeHelper(notificationConfigurationOptions);
        }

        /// <summary>
        ///     Handle command.
        /// </summary>
        /// <param name="request"> Command. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> A task with representation of the void type. </returns>
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var chatId = request
                .Chat
                .Id;

            _logger.LogInformation("{0}Handle begins for chatId={1}.",
                nameof(StartCommand),
                chatId);

            var firstNotificationDateTime = _dateTimeHelper.GetFirstNotificationDateTime();
            var timer = new Timer(
                async _ => await BotService
                    .Client
                    .SendTextMessageAsync(chatId, BotAnswer.NotificationMessage,  cancellationToken:cancellationToken),
                null,
                firstNotificationDateTime.DueTime,
                TimeSpan.FromSeconds(30)
            );

            await TimerDictionary.AddAsync(chatId, timer);

            _logger.LogInformation(firstNotificationDateTime.LogMessage);

            var message = string.Format(BotAnswer.NotificationsAreEnabled,
                firstNotificationDateTime.RussianDayOfWeekName,
                firstNotificationDateTime.MoscowShortTime);
            
            await BotService
                .Client
                .SendTextMessageAsync(chatId,
                    message,
                    cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}