using System.Linq;
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

            var senderUsername = update.Message.From.Username;
            
            return $"chatId={chat.Id},chatName={chatName},from={senderUsername},text={text}";
        }

        internal static bool IsBotCommand(this Update update)
        {
            var messageEntityType = update.Message.Entities.FirstOrDefault()?.Type;
            return messageEntityType == MessageEntityType.BotCommand;
        }
    }
}