using System;
using NUnit.Framework;
using ThursdayMeetingBot.Web.Helpers;

namespace UnitTests.ThursdayMeetingBot.Web.Helpers
{
    public class DateTimeHelperTests
    {
        [Test]
        public void GetDayOfWeekRussianDescription_Sunday_SundayInRussianInParentCase()
        {
            var sunday = new DateTime(2021, 6, 27);
            Assert.AreEqual(DayOfWeek.Sunday, sunday.DayOfWeek);

            var result = DateTimeHelper.GetDayOfWeekRussianDescription(sunday);

            Assert.AreEqual("воскресеньям", result);
        }
        
        [Test]
        public void GetDayOfWeekRussianDescription_Saturday_SaturdayInRussianInParentCase()
        {
            var saturday = new DateTime(2021, 7, 3);
            Assert.AreEqual(DayOfWeek.Saturday, saturday.DayOfWeek);

            var result = DateTimeHelper.GetDayOfWeekRussianDescription(saturday);

            Assert.AreEqual("субботам", result);
        }
    }
}