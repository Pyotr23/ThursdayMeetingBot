using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("UnitTests.ThursdayMeetingBot.Web")]
namespace ThursdayMeetingBot.Libraries.Core.Constants
{
    /// <summary>
    ///     Date and time constants.
    /// </summary>
    public static class DateTimeConstant
    {
        /// <summary>
        ///     Names of days of the week in Russian in the plural in the genitive case.
        /// </summary>
        public static readonly string[] DayOfWeekRussianDescriptions = 
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
        ///     Names of months in Russian in the plural in the genitive case.
        /// </summary>
        public static readonly string[] MonthRussianDescriptions =
        {
            "января",
            "февраля",
            "марта",
            "апреля",
            "мая",
            "июня",
            "июля",
            "августа",
            "сентября",
            "октября",
            "ноября",
            "декабря"
        };

        /// <summary>
        ///     Moscow time zone.
        /// </summary>
        public const int MoscowTimeZone = 3;
        
        
    }
}