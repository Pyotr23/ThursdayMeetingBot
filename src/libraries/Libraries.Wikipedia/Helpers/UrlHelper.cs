using System;
using System.Linq;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Helpers
{
    internal static class UrlHelper
    {
        private static readonly string[] MonthRussianDescriptions =
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
        ///     The format of the day in the Libraries.Wikipedia's url.
        /// </summary>
        private const string WikiDayFormat = "{0}_{1}";

        /// <summary>
        ///     Request format for getting information about the day.
        /// </summary>
        private const string WikiDayFullAddressFormat
            = "https://ru.wikipedia.org/w/index.php?title={0}";
        
        internal static string CreateWikiDayFullAddress()
        {
            var utcNow = DateTime.UtcNow;
            var dayNumber = utcNow.Day;
            var monthNumber = utcNow.Month;
            var russianMonth = MonthRussianDescriptions
                .ElementAtOrDefault(monthNumber - 1);

            if (russianMonth is null)
                throw new IndexOutOfRangeException($"There isn't month with index={monthNumber}");

            var wikiUrlDay = string.Format(WikiDayFormat, 
                dayNumber, 
                russianMonth);

            return string.Format(WikiDayFullAddressFormat, wikiUrlDay);
        }
    }
}