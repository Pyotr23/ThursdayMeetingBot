﻿using MediatR;
using Telegram.Bot.Types;

namespace ThursdayMeetingBot.TelegramBot.MediatR.Commands
{
    /// <summary>
    ///     Command when "/start" received
    /// </summary>
    public record StartCommand : BaseBotCommand<Unit>
    {
        /// <inheritdoc />
        public StartCommand(Message message) : base(message)
        {
        }
    }
}