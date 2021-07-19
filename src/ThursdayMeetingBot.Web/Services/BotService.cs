using Microsoft.Extensions.Options;
using Telegram.Bot;
using ThursdayMeetingBot.Libraries.Core.Interfaces.Bot;
using ThursdayMeetingBot.Web.Configurations;
using ThursdayMeetingBot.Web.Helpers;

namespace ThursdayMeetingBot.Web.Services
{
    /// <inheritdoc />
    public class BotService : IBotService
    {
        /// <inheritdoc />
        public TelegramBotClient Client { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="config"> Bot configuration options. </param>
        public BotService(IOptions<BotConfiguration> config)
        {
            var accessToken = EnvironmentHelper.IsDevelopment()
                ? config
                    .Value
                    .AccessToken
                : EnvironmentHelper.GetBotAccessToken();

            Client = new TelegramBotClient(accessToken);
        }
    }
}