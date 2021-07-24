using System;
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
    }
}