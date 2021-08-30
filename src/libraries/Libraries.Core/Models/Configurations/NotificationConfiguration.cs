using System;

namespace ThursdayMeetingBot.Libraries.Core.Models.Configurations
{
    /// <summary>
    ///     Configuration for an notification.
    /// </summary>
    public record NotificationConfiguration
    {
        /// <summary>
        ///     The day of the week on which the notification will occur.
        /// </summary>
        public string DayOfWeek { get; init; }
        
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