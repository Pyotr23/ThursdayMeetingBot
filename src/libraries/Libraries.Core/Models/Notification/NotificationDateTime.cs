using System;
using ThursdayMeetingBot.Libraries.Core.Extensions;
using ThursdayMeetingBot.Libraries.Core.Helpers;

namespace ThursdayMeetingBot.Libraries.Core.Models.Notification
{
    /// <summary>
    ///     Notification time class.
    /// </summary>
    public record NotificationDateTime
    {
        /// <summary>
        ///     Value.
        /// </summary>
        public DateTime Value { get; }
        
        /// <summary>
        ///     Day of week.
        /// </summary>
        public DayOfWeek DayOfWeek => Value.DayOfWeek;
        
        /// <summary>
        ///     Russian description of day of week.
        /// </summary>
        public string RussianDayOfWeekName => DateTimeHelper. GetDayOfWeekRussianDescription(Value);
        
        /// <summary>
        ///     Value in Moscow time zone.
        /// </summary>
        public string MoscowShortTime => Value.ToMoscowTime().ToShortTimeString();
        
        /// <summary>
        ///     Time until notification.
        /// </summary>
        public TimeSpan DueTime => Value - DateTime.UtcNow;

        /// <summary>
        ///     Formatted time until notification.
        /// </summary>
        public string FormattedDueTime => DueTime.ToString(@"d\.hh\:mm");

        /// <summary>
        ///     Message for logging.
        /// </summary>
        public string LogMessage =>
            $"Notifications are enabled, every {DayOfWeek}, {MoscowShortTime}, after {FormattedDueTime}.";

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dateTime"> The date and time to create the entity for. </param>
        public NotificationDateTime(DateTime dateTime)
        {
            Value = dateTime;
        }
    }
}