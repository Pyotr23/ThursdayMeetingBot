using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using ThursdayMeetingBot.Web.Interfaces;

namespace ThursdayMeetingBot.Web.Quartz.Jobs
{
    /// <summary>
    ///     Job for notify telegram chat.
    /// </summary>
    public class TextNotificationJob : IJob
    {
        private readonly ILogger<TextNotificationJob> _logger;
        private readonly IBotService _botService;
        
        /// <summary>
        ///     Notification text message.
        /// </summary>
        public string NotificationMessage { private get; set; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="botService"> Bot service. </param>
        public TextNotificationJob(
            ILogger<TextNotificationJob> logger, IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }
        
        /// <summary>
        ///     Send a text message to the channel.
        /// </summary>
        /// <param name="context"> IJobExecutionContext. </param>
        public async Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;

            NotificationMessage = dataMap.GetString(nameof(NotificationMessage));
            
            var keyName = context
                .JobDetail
                .Key
                .Name;

            if (!long.TryParse(keyName, out var chatId))
                _logger.LogError($"Can't convert {keyName} to chat id");
            
            var result = await _botService
                .Client
                .SendTextMessageAsync(chatId, NotificationMessage, cancellationToken: context.CancellationToken);

            if (result is null)
            {
                _logger.LogInformation($"Send a text message to the chat {chatId}");
                return;
            }
            
            _logger.LogError($"Chat {chatId} isn't notified");
        }
    }
}