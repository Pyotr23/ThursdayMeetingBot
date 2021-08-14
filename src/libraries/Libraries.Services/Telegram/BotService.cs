using System;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using ThursdayMeetingBot.Libraries.Core.Constants;
using ThursdayMeetingBot.Libraries.Core.Helpers;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;

namespace ThursdayMeetingBot.Libraries.Services.Telegram
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