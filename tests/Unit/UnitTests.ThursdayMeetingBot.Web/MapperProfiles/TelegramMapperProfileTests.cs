using AutoMapper;
using NUnit.Framework;
using ThursdayMeetingBot.Web.MapperProfiles;

namespace Tests.Unit.ThursdayMeetingBot.Web.MapperProfiles
{
    public class TelegramMapperProfileTests
    {
        [Test]
        public void AutoMapper_TelegramMapperProfile_IsValid()
        {
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile<TelegramMapperProfile>());
            
            config.AssertConfigurationIsValid();
        }
    }
}