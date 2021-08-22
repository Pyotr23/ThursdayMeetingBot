using System;
using System.Linq;
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
        /// <param name="text"> The text from the site that needs to be cleared of unnecessary words. </param>
        internal Holiday(string text)
        {
            ClearText(ref text);
            Text = text;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="countryName"> Country name with unnecessary symbols. </param>
        /// <param name="text"> The text from the site that needs to be cleared of unnecessary words. </param>
        internal Holiday(string countryName, string text)
        {
            countryName = GetPartBeforeColons(countryName);
            ClearText(ref countryName);
            ClearText(ref text);
            Text = text.Contains(" — ")
                ? countryName + ", " + text
                : countryName + " — " + text;
        }

        private static string GetPartBeforeColons(string text)
        {
            var chars = text
                .TakeWhile(c => c != ':')
                .ToArray();
            
            return new string(chars);
        }

        private static void ClearText(ref string text)
        {
            ConfirmRegexReplace(ref text);
            Trim(ref text);
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            text = string.Join(' ', words); 
        }

        private static void ConfirmRegexReplace(ref string text)
        {
            text = new Regex(Pattern)
                .Replace(text, " ");
        }

        private static void Trim(ref string text)
        {
            text = text
                .Trim()
                .TrimEnd('.')
                .TrimEnd();
        }
    }
}