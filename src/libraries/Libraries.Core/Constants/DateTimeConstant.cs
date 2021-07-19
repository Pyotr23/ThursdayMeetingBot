namespace ThursdayMeetingBot.Libraries.Core.Constants
{
    /// <summary>
    ///     Date and time constants.
    /// </summary>
    public static class DateTimeConstant
    {
        /// <summary>
        ///     The number of days in a week.
        /// </summary>
        public const int DaysInWeek = 7;

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
        ///     Moscow time zone.
        /// </summary>
        public const int MoscowTimeZone = 3;
    }
}