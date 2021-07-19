using System;
using NUnit.Framework;
using ThursdayMeetingBot.Libraries.Core.Extensions;
using ThursdayMeetingBot.Web.Extensions;

namespace ThursdayMeetingBot.UnitTests.TelegramBot.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Test]
        public void ToMoscowTime_AnyDateTime_AddThreeHours()
        {
            var utcDateTime = DateTime.UtcNow;

            var result = utcDateTime.ToMoscowTime();
            
            Assert.AreEqual(utcDateTime.AddHours(3), result);
        }
    }
}