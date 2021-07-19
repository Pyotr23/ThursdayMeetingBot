using System;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using ThursdayMeetingBot.Web.Configurations;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Helpers;
using ThursdayMeetingBot.Web.Interfaces;

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
                : Environment.GetEnvironmentVariable(EnvironmentConstant.BotAccessTokenAlias);

            Client = new TelegramBotClient(accessToken);
        }
    }
}