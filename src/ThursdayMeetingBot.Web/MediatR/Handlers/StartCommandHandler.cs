using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.Libraries.Core.Constants;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Models.Quartz;
using ThursdayMeetingBot.Libraries.Core.Services.Quartz;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;
using ThursdayMeetingBot.Web.Helpers;
using ThursdayMeetingBot.Web.MediatR.Commands;
using ThursdayMeetingBot.Web.Models.Notification;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler<TUserDto> : IRequestHandler<StartCommand, Unit>
        where TUserDto : UserDto, new()
    {
        private readonly ILogger<StartCommandHandler<TUserDto>> _logger;
        private readonly NotificationConfiguration _configuration;
        private readonly IQuartzService _quartzService;
        private readonly IBotService _botService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="options"> Notification settings from appsettings. </param>
        /// <param name="quartzService"> Service for working with Quartz library. </param>
        /// <param name="botService"> Bot service for answer. </param>
        public StartCommandHandler(ILogger<StartCommandHandler<TUserDto>> logger,
            IOptions<NotificationConfiguration> options, 
            IQuartzService quartzService,
            IBotService botService)
        {
            _logger = logger;
            _configuration = options.Value;
            _quartzService = quartzService;
            _botService = botService;
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

            _logger.LogInformation($"[{request.Id}] Handle of start command");

            var stringChatId = request
                .ChatId
                .ToString();
            var startAt = DateTimeHelper.GetCurrentWeekNotificationDateTime(_configuration);
            var notificationInfo = new NotificationInfo(stringChatId, startAt);

            await _quartzService.ScheduleJobAsync(notificationInfo, cancellationToken);

            var notificationDateTime = new NotificationDateTime(_configuration);

            var answer = string.Format(BotAnswer.NotificationsAreEnabled,
                notificationDateTime.RussianDayOfWeekName,
                notificationDateTime.MoscowShortTime);
            
            await _botService
                .Client
                .SendTextMessageAsync(request.ChatId, answer, cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}