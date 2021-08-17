﻿namespace ThursdayMeetingBot.Libraries.Core.Services.Wikipedia
{
    /// <summary>
    ///     Service for getting info from Wikipedia. 
    /// </summary>
    public interface IWikiService
    {
        /// <summary>
        ///     Get holiday info.
        /// </summary>
        /// <returns> String with date and description of holiday. </returns>
        string GetHoliday();
    }
}