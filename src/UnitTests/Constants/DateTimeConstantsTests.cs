using NUnit.Framework;
using ThursdayMeetingBot.TelegramBot.Constants;

namespace UnitTests.Constants
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