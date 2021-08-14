using System;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Web.Extensions;
using ThursdayMeetingBot.Web.Helpers;

namespace ThursdayMeetingBot.Web.Models.Notification
{
    /// <summary>
    ///     Notification time class.
    /// </summary>
    internal sealed record NotificationDateTime
    {
        /// <summary>
        ///     Value.
        /// </summary>
        private DateTime Value { get; }

        /// <summary>
        ///     Russian description of day of week.
        /// </summary>
        internal string RussianDayOfWeekName => Value.ToDayOfWeekRussianDescription();
        
        /// <summary>
        ///     Value in Moscow time zone.
        /// </summary>
        internal string MoscowShortTime => Value.ToMoscowTime().ToShortTimeString();
        
        internal NotificationDateTime(NotificationConfiguration configuration)
        {
            Value = DateTimeHelper.GetCurrentWeekNotificationDateTime(configuration);
        }
    }
}