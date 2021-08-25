namespace ThursdayMeetingBot.Libraries.Core.Models.Quartz
{
    /// <summary>
    ///     Information for creating a notification.
    /// </summary>
    /// <param name="ChatId"> Telegram chat id. </param>
    /// <param name="NotificationMessage"> Notification message. </param>
    public record NotificationInfo(long ChatId, string NotificationMessage);
}