using System;

namespace ThursdayMeetingBot.Web.Configurations
{
    /// <summary>
    ///     Configuration for an notification.
    /// </summary>
    public record NotificationConfiguration
    {
        /// <summary>
        ///     The day of the week on which the notification will occur.
        /// </summary>
        public DayOfWeek DayOfWeek { get; init; }
        
        /// <summary>
        ///     Notification UTC hour.
        /// </summary>
        public int Hour { get; init; }
        
        /// <summary>
        ///     Minute of notification.
        /// </summary>
        public int Minute { get; init; }
    }
}