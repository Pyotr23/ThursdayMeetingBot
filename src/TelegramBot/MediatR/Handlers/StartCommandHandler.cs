using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Constants;
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
        private readonly NotificationConfiguration _configuration;

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
            _configuration = notificationConfigurationOptions.Value;
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

            var chat = request.Chat;

            _logger.LogInformation("{0}Handle begins for chatId={1}.",
                nameof(StartCommand),
                chat.Id);

            var dueTime = GetFirstNotificationDateTime() - DateTime.UtcNow;
            var timer = new Timer(
                async _ => await BotService
                    .Client
                    .SendTextMessageAsync(chat.Id, "Go to drink!",  cancellationToken:cancellationToken),
                null,
                dueTime,
                TimeSpan.FromSeconds(DateTimeConstant.DaysInWeek)
            );

            return Unit.Value;
        }

        private DateTime GetFirstNotificationDateTime()
        {
            var utcNow = DateTime.UtcNow;
            var previousSunday = utcNow
                .AddDays(-1 * (int)utcNow.DayOfWeek)
                .Date;
            var notificationDateTimeForCurrentWeek = previousSunday
                .AddDays((int)_configuration.DayOfWeek)
                .AddHours(_configuration.Hour)
                .AddMinutes(_configuration.Minute);
            return notificationDateTimeForCurrentWeek < utcNow
                ? notificationDateTimeForCurrentWeek.AddDays(DateTimeConstant.DaysInWeek)
                : notificationDateTimeForCurrentWeek;
        }
    }
}