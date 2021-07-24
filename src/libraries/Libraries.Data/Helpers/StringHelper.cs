using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("UnitTests.ThursdayMeetingBot.Libraries.Data")]
namespace ThursdayMeetingBot.Libraries.Data.Helpers
{
    internal static class StringHelper
    {
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