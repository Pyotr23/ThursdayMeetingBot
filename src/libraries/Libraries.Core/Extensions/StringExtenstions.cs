using System;
using ThursdayMeetingBot.Libraries.Core.Constants;

namespace ThursdayMeetingBot.Libraries.Core.Extensions
{
    /// <summary>
    ///     Extension methods of type "string".
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Get the first letters of text. Their number is taken from the constants or is text size.
        /// </summary>
        /// <param name="str"> Text. </param>
        /// <returns> First letters of text. </returns>
        public static string GetFirstLetters(this string str)
        {
            var lastLetterIndex = Math.Min(str.Length, StringConstant.FirstLettersNumber);
            return str[..lastLetterIndex];
        }
    }
}