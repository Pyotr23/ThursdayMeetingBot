using ThursdayMeetingBot.Libraries.Data.Helpers;
using Xunit;

namespace Tests.Unit.ThursdayMeetingBot.Libraries.Data.Helpers
{
    public class StringHelperTests
    {
        [Fact]
        public void ToSnakeCase_NullString_ReturnNull()
        {
            var outputString = StringHelper.ToSnakeCase(null);

            Assert.Null(outputString);
        }

        [Fact]
        public void ToSnakeCase_EmptyString_ReturnEmptyString()
        {
            var inputString = string.Empty;

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal(string.Empty, outputString);
        }

        [Fact]
        public void ToSnakeCase_CamelCaseString_ReturnSnakeCaseString()
        {
            const string inputString = "OneTwoThree";

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal("one_two_three", outputString);
        }

        [Fact]
        public void ToSnakeCase_SmallCamelCaseString_ReturnSnakeCaseString()
        {
            const string inputString = "oneTwoThree";

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal("one_two_three", outputString);
        }

        [Fact]
        public void ToSnakeCase_SnakeCaseString_ReturnSnakeCaseString()
        {
            const string inputString = "one_two_three";

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal(outputString, outputString);
        }

        [Fact]
        public void ToSnakeCase_SnakeCaseStringWithDigitsBeforeUpperCase_ReturnSnakeCaseString()
        {
            const string inputString = "One1Two2Three3";

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal("one1_two2_three3", outputString);
        }

        [Fact]
        public void ToSnakeCase_SnakeCaseStringWithDigitsInWordMiddle_ReturnSnakeCaseString()
        {
            const string inputString = "On1eTw2oThre3e";

            var outputString = StringHelper.ToSnakeCase(inputString);

            Assert.Equal("on1e_tw2o_thre3e", outputString);
        }
    }
}