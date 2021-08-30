using System;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;

namespace ThursdayMeetingBot.Web.Helpers
{
    internal static class DateTimeHelper
    {
        internal static DateTime GetCurrentWeekNotificationDateTime(NotificationConfiguration configuration)
        {
            Enum.TryParse<DayOfWeek>(configuration.DayOfWeek, ignoreCase: true, out var dayOfWeek);
            return GetPreviousSundayBeginning()
                .AddDays((int) dayOfWeek)
                .AddHours(configuration.Hour)
                .AddMinutes(configuration.Minute);
        }

        private static DateTime GetPreviousSundayBeginning()
        {
            var utcNow = DateTime.UtcNow;

            return utcNow
                .AddDays(-1 * (int) utcNow.DayOfWeek)
                .Date;
        }
    }
}