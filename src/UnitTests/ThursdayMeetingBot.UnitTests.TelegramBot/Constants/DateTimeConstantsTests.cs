﻿using NUnit.Framework;
using ThursdayMeetingBot.Libraries.Core.Constants;

namespace ThursdayMeetingBot.UnitTests.TelegramBot.Constants
{
    public class DateTimeConstantsTests
    {
        [Test]
        public void DayOfWeekRussianDescriptions_LengthIsEqualSeven()
        {
            var result = DateTimeConstant.DayOfWeekRussianDescriptions;
            
            Assert.AreEqual(7, result.Length);
        }
    }
}