using System;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Constants;
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
        public BotService()
        {
            var accessToken = Environment.GetEnvironmentVariable(EnvironmentConstant.BotAccessTokenAlias);
            Client = new TelegramBotClient(accessToken);
        }
    }
}