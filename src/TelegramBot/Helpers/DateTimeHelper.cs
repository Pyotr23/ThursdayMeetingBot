using System;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Constants;

namespace ThursdayMeetingBot.TelegramBot.Helpers
{
    /// <summary>
    ///     DateTime helper.
    /// </summary>
    public class DateTimeHelper
    {
        private readonly NotificationConfiguration _configuration;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="notificationConfigurationOptions"></param>
        public DateTimeHelper(IOptions<NotificationConfiguration> notificationConfigurationOptions)
        {
            _configuration = notificationConfigurationOptions.Value;
        }
        
        /// <summary>
        ///     Get the date and the time of the first notification.
        /// </summary>
        /// <returns></returns>
        public DateTime GetFirstNotificationDateTime()
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
                ? notificationDateTimeForCurrentWeek.AddDays(DateTimeConstant.DaysInWeek)
                : notificationDateTimeForCurrentWeek;
        }

        /// <summary>
        ///     Get the day of the week in Russian in the parent plural case.
        /// </summary>
        /// <param name="dateTime"> Date with time. </param>
        /// <returns> Day of the week in Russian in the parent plural case. </returns>
        public static string GetDayOfWeekRussianDescription(DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek;
            var dayOfWeekIndex = (int) dayOfWeek;
            if (dayOfWeekIndex < DateTimeConstant.DayOfWeekRussianDescription.Length)
                return DateTimeConstant.DayOfWeekRussianDescription[dayOfWeekIndex];
            throw new ArgumentOutOfRangeException($"No russian description for the {dayOfWeek}.");
        }
    }
}