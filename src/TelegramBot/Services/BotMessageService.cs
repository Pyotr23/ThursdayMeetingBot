using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using ThursdayMeetingBot.TelegramBot.Interfaces;

namespace ThursdayMeetingBot.TelegramBot.Services
{
    /// <inheritdoc />
    public class BotMessageService : IBotMessageService
    {
        private readonly ILogger<BotMessageService> _logger;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        public BotMessageService(ILogger<BotMessageService> logger)
        {
            _logger = logger;
        }
        
        /// <inheritdoc />
        public async Task ProcessAsync(Update messageEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}