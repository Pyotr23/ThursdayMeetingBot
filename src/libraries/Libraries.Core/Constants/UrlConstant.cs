namespace ThursdayMeetingBot.Libraries.Core.Constants
{
    /// <summary>
    ///     Url constants.
    /// </summary>
    public class UrlConstant
    {
        /// <summary>
        ///     The format of the day in the Wikipedia's url.
        /// </summary>
        public const string WikiDayFormat = "{0}_{1}";

        /// <summary>
        ///     Request format for getting information about the day.
        /// </summary>
        public const string WikiDayFullAddressFormat
            = "https://ru.wikipedia.org/w/index.php?title={0}";
    }
}