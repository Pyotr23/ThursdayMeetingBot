using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Dictionaries;
using ThursdayMeetingBot.TelegramBot.Extensions;
using ThursdayMeetingBot.TelegramBot.Helpers;
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
        /// <returns></returns>
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
                    .SendTextMessageAsync(chatId, "Go to drink!",  cancellationToken:cancellationToken),
                null,
                firstNotificationDateTime.DueTime,
                TimeSpan.FromSeconds(30)
            );

            await TimerDictionary.AddAsync(chatId, timer);
           
            var responseText = string.Format("Включены уведомления о встречах по {0} в {1}.",
                firstNotificationDateTime.RussianDayOfWeekName,
                firstNotificationDateTime.MoscowShortTime);
            
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