using System.Text.RegularExpressions;

namespace ThursdayMeetingBot.Libraries.Data.Extensions
{
    /// <summary>
    ///     Extensions for string objects.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Extension method for transforming string in CamelCase to SnakeCase format.
        /// </summary>
        /// <param name="input"> Format string. </param>
        /// <returns> Formatted string. </returns>
        public static string ToSnakeCase(this string input)
        {
            return string.IsNullOrEmpty(input)
                ? input
                : Regex
                    .Replace(input, @"([a-z0-9])([A-Z])", "$1_$2")
                    .ToLower();
        }
    }
}