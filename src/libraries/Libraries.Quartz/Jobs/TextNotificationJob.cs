using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using ThursdayMeetingBot.Libraries.Core.Constants;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;

namespace ThursdayMeetingBot.Libraries.Quartz.Jobs
{
    /// <summary>
    ///     Job for notify telegram chat.
    /// </summary>
    public class TextNotificationJob : IJob
    {
        private readonly ILogger<TextNotificationJob> _logger;
        private readonly IBotService _botService;
        private readonly IWikiService _wikiService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="botService"> Bot service. </param>
        /// <param name="wikiService"> Service for Wikipedia parsing. </param>
        public TextNotificationJob(
            ILogger<TextNotificationJob> logger, 
            IBotService botService,
            IWikiService wikiService
            )
        {
            _logger = logger;
            _botService = botService;
            _wikiService = wikiService;
        }
        
        /// <summary>
        ///     Send a text message to the channel.
        /// </summary>
        /// <param name="context"> IJobExecutionContext. </param>
        public async Task Execute(IJobExecutionContext context)
        {
            var keyName = context
                .JobDetail
                .Key
                .Name;

            if (!long.TryParse(keyName, out var chatId))
                _logger.LogError($"Can't convert {keyName} to chat id");

            var holiday = await _wikiService.GetHolidayTextAsync();

            var notificationText = string.IsNullOrEmpty(holiday)
                ? BotAnswer.NotificationMessageWithoutReason
                : BotAnswer.NotificationMessageWithReason + holiday;

            var result = await _botService
                .Client
                .SendTextMessageAsync(chatId, notificationText, cancellationToken: context.CancellationToken);

            if (result is null)
            {
                _logger.LogError($"Chat {chatId} isn't notified");
                return;
            }
            
            _logger.LogInformation($"Send a text message to the chat {chatId}");
        }
    }
}