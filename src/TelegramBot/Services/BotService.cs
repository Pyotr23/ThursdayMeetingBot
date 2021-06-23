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
        /// <param name="botConfiguration"> Bot configuration. </param>
        public BotService(IOptions<BotConfiguration> botConfiguration)
        {
            var accessToken = botConfiguration
                .Value
                .AccessToken;

            Client = new TelegramBotClient(accessToken);
        }
    }
}