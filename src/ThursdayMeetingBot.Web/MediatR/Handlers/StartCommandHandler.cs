using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Web.Configurations;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Dictionaries;
using ThursdayMeetingBot.Web.Helpers;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Command "/start" handler.
    /// </summary>
    public class StartCommandHandler<TUserDto> : BotCommandHandler, IRequestHandler<StartCommand, Unit>
        where TUserDto : UserDto, new()
    {
        private readonly ILogger<StartCommandHandler<TUserDto>> _logger;
        private readonly DateTimeHelper _dateTimeHelper;
        private readonly IUserService<TUserDto> _userService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="notificationConfigurationOptions"> Notification settings from appsettings. </param>
        /// <param name="botService"> Bot service. </param>
        public StartCommandHandler(ILogger<StartCommandHandler<TUserDto>> logger,
            IOptions<NotificationConfiguration> notificationConfigurationOptions, 
            IUserService<TUserDto> userService,
            IBotService botService)
            : base(botService)
        {
            _logger = logger;
            _userService = userService;
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

            var userDto = new TUserDto();
            var telegramUser = request.Message.From;
            userDto.Id = telegramUser.Id;
            userDto.FirstName = telegramUser.FirstName;
            userDto.LastName = telegramUser.LastName;
            userDto.Username = telegramUser.Username;
           
            await _userService.Register(userDto, cancellationToken);

            await BotService
                .Client
                .SendTextMessageAsync(chatId,
                    firstNotificationDateTime.BotMessage,
                    cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}