using System;
using ThursdayMeetingBot.Web.Constants;

namespace ThursdayMeetingBot.Web.Extensions
{
    internal static class StringExtensions
    {
        internal static string GetFirstLetters(this string str)
        {
            var lastLetterIndex = Math.Min(str.Length, StringConstant.FirstLettersNumber);
            return str[..lastLetterIndex];
        }
    }
}