using System;
using ThursdayMeetingBot.Libraries.Core.Extensions;
using ThursdayMeetingBot.Libraries.Core.Helpers;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;

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
        private DateTime Value { get; }
        
        /// <summary>
        ///     Day of week.
        /// </summary>
        private DayOfWeek DayOfWeek => Value.DayOfWeek;
        
        /// <summary>
        ///     Russian description of day of week.
        /// </summary>
        private string RussianDayOfWeekName => Value.ToDayOfWeekRussianDescription();
        
        /// <summary>
        ///     Value in Moscow time zone.
        /// </summary>
        private string MoscowShortTime => Value.ToMoscowTime().ToShortTimeString();
        
        /// <summary>
        ///     Time until notification.
        /// </summary>
        internal TimeSpan DueTime => Value - DateTime.UtcNow;

        /// <summary>
        ///     Formatted time until notification.
        /// </summary>
        private string FormattedDueTime => DueTime.ToString(@"d\.hh\:mm");

        // /// <summary>
        // ///     Bot answer.
        // /// </summary>
        // public string BotMessage => 
        //     string.Format(BotAnswer.NotificationsAreEnabled,
        //         RussianDayOfWeekName,
        //         MoscowShortTime);
        
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

        public NotificationDateTime(NotificationConfiguration configuration)
        {
            Value = DateTimeHelper.GetCurrentWeekNotificationDateTime(configuration);
        }
    }
}