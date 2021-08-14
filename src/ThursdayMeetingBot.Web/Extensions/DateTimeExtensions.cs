using System;
using System.Linq;
using ThursdayMeetingBot.Web.Constants;

namespace ThursdayMeetingBot.Web.Extensions
{
    /// <summary>
    ///     Date and time extensions.
    /// </summary>
    internal static class DateTimeExtensions
    {
        /// <summary>
        ///     Convert UTC time to Moscow time.
        /// </summary>
        /// <param name="utcDateTime"> UTC time. </param>
        /// <returns> Moscow time. </returns>
        internal static DateTime ToMoscowTime(this DateTime utcDateTime)
        {
            return utcDateTime.AddHours(DateTimeConstant.MoscowTimeZone);
        }
        
        /// <summary>
        ///     Get the day of the week in Russian in the parent plural case.
        /// </summary>
        /// <param name="dateTime"> Date with time. </param>
        /// <returns> Day of the week in Russian in the parent plural case. </returns>
        internal static string ToDayOfWeekRussianDescription(this DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek;
            var dayOfWeekIndex = (int) dayOfWeek;
            if (dayOfWeekIndex < DateTimeConstant.DayOfWeekRussianDescriptions.Length)
                return DateTimeConstant.DayOfWeekRussianDescriptions.ElementAt(dayOfWeekIndex);
            throw new ArgumentOutOfRangeException($"No russian description for the {dayOfWeek}.");
        }
    }
}