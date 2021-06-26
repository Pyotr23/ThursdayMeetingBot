using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.TelegramBot.Configurations;
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
        /// <param name="botService"> Bot service. </param>
        /// <param name="logger"> Logger. </param>
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

            var utcNow = DateTime.UtcNow;
            if (utcNow.DayOfWeek <= _configuration.DayOfWeek
                && utcNow.Hour <= _configuration.Hour
                && utcNow.Minute < _configuration.Minute)
            {
                var weekBeginning = utcNow.Date.AddDays(-1 * (int)utcNow.DayOfWeek);
                var timer = new Timer(
                    async _ => await BotService.Client.SendTextMessageAsync(chat.Id, "Go to drink!",  cancellationToken:cancellationToken),
                    null,
                    );
            }
            var notificationDateTime = new DateTime(utcNow.Year, utcNow.Month)

            return Unit.Value;
        }
    }
}