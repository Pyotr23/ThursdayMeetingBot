using System;
using ThursdayMeetingBot.Libraries.Core.Constants;

namespace ThursdayMeetingBot.Libraries.Core.Extensions
{
    /// <summary>
    ///     Date and time extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Convert UTC time to Moscow time.
        /// </summary>
        /// <param name="utcDateTime"> UTC time. </param>
        /// <returns> Moscow time. </returns>
        public static DateTime ToMoscowTime(this DateTime utcDateTime)
        {
            return utcDateTime.AddHours(DateTimeConstant.MoscowTimeZone);
        }
    }
}