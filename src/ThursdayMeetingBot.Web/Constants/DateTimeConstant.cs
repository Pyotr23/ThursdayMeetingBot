using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("UnitTests.ThursdayMeetingBot.Web")]
namespace ThursdayMeetingBot.Web.Constants
{
    /// <summary>
    ///     Date and time constants.
    /// </summary>
    internal static class DateTimeConstant
    {
        /// <summary>
        ///     The number of days in a week.
        /// </summary>
        internal const int DaysInWeek = 7;

        /// <summary>
        ///     Names of days of the week in Russian in the plural in the genitive case.
        /// </summary>
        internal static readonly string[] DayOfWeekRussianDescriptions = 
        {
            "воскресеньям",
            "понедельникам",
            "вторникам",
            "средам",
            "четвергам",
            "пятницам",
            "субботам"
        };

        /// <summary>
        ///     Moscow time zone.
        /// </summary>
        internal const int MoscowTimeZone = 3;
    }
}