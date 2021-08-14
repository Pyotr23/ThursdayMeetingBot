using System;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;

namespace ThursdayMeetingBot.Libraries.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetCurrentWeekNotificationDateTime(NotificationConfiguration configuration)
        {
            return GetPreviousSundayBeginning()
                .AddDays((int) configuration.DayOfWeek)
                .AddHours(configuration.Hour)
                .AddMinutes(configuration.Minute);
        }
        
        private static DateTime GetPreviousSundayBeginning()
        {
            var utcNow = DateTime.UtcNow;

            return utcNow
                .AddDays(-1 * (int)utcNow.DayOfWeek)
                .Date;
        }
    }
}