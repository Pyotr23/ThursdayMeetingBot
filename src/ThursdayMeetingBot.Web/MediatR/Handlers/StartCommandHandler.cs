using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Quartz.Interfaces;
using ThursdayMeetingBot.Libraries.Quartz.Models;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Helpers;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler<TUserDto> : IRequestHandler<StartCommand, Unit>
        where TUserDto : UserDto, new()
    {
        private readonly ILogger<StartCommandHandler<TUserDto>> _logger;
        private readonly DateTimeHelper _dateTimeHelper;
        private readonly IQuartzService _quartzService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="notificationConfigurationOptions"> Notification settings from appsettings. </param>
        /// <param name="quartzService"> Service for working with Quartz library. </param>
        public StartCommandHandler(ILogger<StartCommandHandler<TUserDto>> logger,
            IOptions<NotificationConfiguration> notificationConfigurationOptions, 
            IQuartzService quartzService)
        {
            _logger = logger;
            _dateTimeHelper = new DateTimeHelper(notificationConfigurationOptions);
            _quartzService = quartzService;
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

            var info = new NotificationInfo(request.ChatId, BotAnswer.NotificationMessage);

            await _quartzService.CreateJobAsync(info, cancellationToken);

            return Unit.Value;
        }
    }
}