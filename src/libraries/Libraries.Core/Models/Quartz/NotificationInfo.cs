using System;

namespace ThursdayMeetingBot.Libraries.Core.Models.Quartz
{
    /// <summary>
    ///     Information for creating a notification.
    /// </summary>
    /// <param name="ChatId"> Telegram chat id in string. </param>
    /// <param name="StartAt"> First notification date time. </param>
    public record NotificationInfo(string ChatId, DateTime StartAt);
}