using System.Text.RegularExpressions;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Models
{
    internal class Holiday
    {
        private const string Pattern 
            = @"(\(англ.\)|русск.|\d?&#\d{2,3};|См\.\s.*|источник не указан.*|\[en\]|\(порт.\)|\(эст.\))";

        internal string Text { get; }
        
        internal Holiday(string rawText)
        {
            Text = new Regex(Pattern)
                .Replace(rawText, " ")
                .Trim()
                .TrimEnd('.');;
        }
    }
}