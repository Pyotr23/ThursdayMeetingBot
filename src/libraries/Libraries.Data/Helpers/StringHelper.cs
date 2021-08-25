using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Tests.Unit.ThursdayMeetingBot.Libraries.Data")]
namespace ThursdayMeetingBot.Libraries.Data.Helpers
{
    /// <summary>
    ///     String helper.
    /// </summary>
    internal static class StringHelper
    {
        /// <summary>
        ///     Convert a string to snake.
        /// </summary>
        /// <param name="str"> String to convert. </param>
        /// <returns> A string in the snake register. </returns>
        internal static string ToSnakeCase(string str)
        {
            const string pattern = @"([a-z0-9])([A-Z])";
            const string replacement = "$1_$2";
            
            return string.IsNullOrEmpty(str)
                ? str
                : Regex
                    .Replace(str, pattern, replacement)
                    .ToLower();
        }
    }
}