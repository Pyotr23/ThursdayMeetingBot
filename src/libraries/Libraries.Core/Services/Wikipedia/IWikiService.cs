using System.Threading.Tasks;

namespace ThursdayMeetingBot.Libraries.Core.Services.Wikipedia
{
    /// <summary>
    ///     Service for getting info from Libraries.Wikipedia. 
    /// </summary>
    public interface IWikiService
    {
        /// <summary>
        ///     Get holiday info.
        /// </summary>
        /// <returns> String with date and description of holiday. </returns>
        Task<string> GetHolidayText();
    }
}