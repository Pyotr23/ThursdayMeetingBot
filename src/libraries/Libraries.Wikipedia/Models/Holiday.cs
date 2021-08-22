using System.Text.RegularExpressions;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Models
{
    /// <summary>
    ///     Holiday.
    /// </summary>
    internal class Holiday
    {
        private const string Pattern 
            = @"(\(англ.\)|русск.|\d?&#\d{2,3};|См\.\s.*|источник не указан.*|\[en\]|\(порт.\)|\(эст.\))";

        /// <summary>
        ///     Text of the holiday.
        /// </summary>
        internal string Text { get; }
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="rawText"> The text from the site that needs to be cleared of unnecessary words. </param>
        internal Holiday(string rawText)
        {
            Text = new Regex(Pattern)
                .Replace(rawText, " ")
                .Trim()
                .TrimEnd('.');;
        }
    }
}