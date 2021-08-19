using System;
using System.Linq;
using ThursdayMeetingBot.Libraries.Wikipedia.Constants;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Helpers
{
    internal static class UrlHelper
    {
        internal static string CreateWikiDayFullAddress()
        {
            var utcNow = DateTime.UtcNow;
            var dayNumber = utcNow.Day;
            var monthNumber = utcNow.Month;
            var russianMonth = DateTimeConstant
                .MonthRussianDescriptions
                .ElementAtOrDefault(monthNumber);

            if (russianMonth is null)
                throw new IndexOutOfRangeException($"There isn't month with index={monthNumber}");

            var wikiUrlDay = string.Format(UrlConstant.WikiDayFormat, 
                dayNumber, 
                russianMonth);

            return string.Format(UrlConstant.WikiDayFullAddressFormat, wikiUrlDay);
        }
    }
}