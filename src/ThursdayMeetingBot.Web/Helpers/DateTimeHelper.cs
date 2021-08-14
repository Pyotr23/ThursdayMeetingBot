using System;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Models;

namespace ThursdayMeetingBot.Web.Helpers
{
    /// <summary>
    ///     DateTime helper.
    /// </summary>
    internal class DateTimeHelper
    {
        private readonly NotificationConfiguration _configuration;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="notificationConfigurationOptions"> Notification configuration. </param>
        internal DateTimeHelper(IOptions<NotificationConfiguration> notificationConfigurationOptions)
        {
            _configuration = notificationConfigurationOptions.Value;
        }
        
        /// <summary>
        ///     Get the date and the time of the first notification.
        /// </summary>
        /// <returns> Class containing the necessary information about the notification time. </returns>
        internal NotificationDateTime GetFirstNotificationDateTime()
        {
            var utcNow = DateTime.UtcNow;
            
            var previousSunday = utcNow
                .AddDays(-1 * (int)utcNow.DayOfWeek)
                .Date;
            
            var notificationDateTimeForCurrentWeek = previousSunday
                .AddDays((int)_configuration.DayOfWeek)
                .AddHours(_configuration.Hour)
                .AddMinutes(_configuration.Minute);
            
            return notificationDateTimeForCurrentWeek < utcNow
                ? new NotificationDateTime(notificationDateTimeForCurrentWeek.AddDays(DateTimeConstant.DaysInWeek))
                : new NotificationDateTime(notificationDateTimeForCurrentWeek);
        }

        /// <summary>
        ///     Get the day of the week in Russian in the parent plural case.
        /// </summary>
        /// <param name="dateTime"> Date with time. </param>
        /// <returns> Day of the week in Russian in the parent plural case. </returns>
        internal static string GetDayOfWeekRussianDescription(DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek;
            var dayOfWeekIndex = (int) dayOfWeek;
            if (dayOfWeekIndex < DateTimeConstant.DayOfWeekRussianDescriptions.Length)
                return DateTimeConstant.DayOfWeekRussianDescriptions[dayOfWeekIndex];
            throw new ArgumentOutOfRangeException($"No russian description for the {dayOfWeek}.");
        }
    }
}