using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ThursdayMeetingBot.Web.Extensions
{
    internal static class UpdateExtensions
    {
        internal static string GetInfo(this Update update)
        {
            var chat = update.Message.Chat;
            
            var chatName = chat.Type == ChatType.Group
                ? chat.Title
                : chat.Username;
            
            var text = update.Message.Text ?? string.Empty;
            if (!string.IsNullOrEmpty(text))
                text = text.GetFirstLetters();
            
            return $"chatId={chat.Id},chatName={chatName},text={text}";
        }
    }
}