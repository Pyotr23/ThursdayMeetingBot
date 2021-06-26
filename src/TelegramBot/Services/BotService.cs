using Microsoft.Extensions.Options;
using Telegram.Bot;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Interfaces;

namespace ThursdayMeetingBot.TelegramBot.Services
{
    /// <inheritdoc />
    public class BotService : IBotService
    {
        /// <inheritdoc />
        public TelegramBotClient Client { get; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="botConfigurationOptions"> Bot configuration options. </param>
        public BotService(IOptions<BotConfiguration> botConfigurationOptions)
        {
            var accessToken = botConfigurationOptions
                .Value
                .AccessToken;
            Client = new TelegramBotClient(accessToken);
        }
    }
}