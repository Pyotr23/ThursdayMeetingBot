namespace ThursdayMeetingBot.Libraries.Wikipedia.Constants
{
    /// <summary>
    ///     Url constants.
    /// </summary>
    internal class UrlConstant
    {
        /// <summary>
        ///     The format of the day in the Libraries.Wikipedia's url.
        /// </summary>
        internal const string WikiDayFormat = "{0}_{1}";

        /// <summary>
        ///     Request format for getting information about the day.
        /// </summary>
        internal const string WikiDayFullAddressFormat
            = "https://ru.wikipedia.org/w/index.php?title={0}";
    }
}