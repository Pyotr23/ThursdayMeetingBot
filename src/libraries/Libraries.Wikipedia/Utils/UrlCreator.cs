using System;
using System.Linq;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Utils
{
    internal static class UrlCreator
    {
        /// <summary>
        ///     Names of months in Russian in the genitive case.
        /// </summary>
        private static readonly string[] MonthRussianDescriptions =
        {
            "Numbering of months begins with 1", 
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
        ///     The format of the day url postfix.
        /// </summary>
        private const string DayUrlPostfixFormat = "{0}_{1}";

        /// <summary>
        ///     Request format for getting information about the day.
        /// </summary>
        private const string DayUrlFormat
            = "https://ru.wikipedia.org/w/index.php?title={0}";

        /// <summary>
        ///     Create a request address for getting a page with information about the day.
        /// </summary>
        /// <param name="date"> Date of the day. </param>
        /// <returns> Address of the site page. </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// The array of names of months in Russian in the genitive case is too short
        /// </exception>
        internal static string CreateDayUrl(DateTime date)
        {
            var day = date.Day;
            var month = date.Month;
            var russianMonth = MonthRussianDescriptions
                .ElementAtOrDefault(month);

            if (russianMonth is null)
                throw new IndexOutOfRangeException($"There isn't month with index {month}");

            var wikiUrlDay = string.Format(DayUrlPostfixFormat, 
                day, 
                russianMonth);

            return string.Format(DayUrlFormat, wikiUrlDay);
        }
        
        /// <summary>
        ///     Create a request address for getting a page with information about the current day.
        /// </summary>
        /// <returns> Address of the site page. </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// The array of names of months in Russian in the genitive case is too short
        /// </exception>
        internal static string CreateDayUrl()
        {
            return CreateDayUrl(DateTime.UtcNow);
        }
    }
}