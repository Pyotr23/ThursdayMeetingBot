using NUnit.Framework;
using ThursdayMeetingBot.Web.Constants;

namespace UnitTests.ThursdayMeetingBot.Web.Constants
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