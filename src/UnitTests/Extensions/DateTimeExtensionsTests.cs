using System;
using NUnit.Framework;
using ThursdayMeetingBot.TelegramBot.Extensions;

namespace UnitTests.Extensions
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