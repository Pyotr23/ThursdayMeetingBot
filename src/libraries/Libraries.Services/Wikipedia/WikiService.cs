using System;
using System.Linq;
using System.Security.Policy;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Constants;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
using ThursdayMeetingBot.Libraries.Services.Wikipedia.Helpers;

namespace ThursdayMeetingBot.Libraries.Services.Wikipedia
{
    /// <summary>
    /// <inheritdoc cref="IWikiService"/>
    /// </summary>
    public class WikiService : IWikiService
    {
        private readonly ILogger<WikiService> _logger;
        private HtmlWeb _htmlWeb = new HtmlWeb();
        
        public WikiService(ILogger<WikiService> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// <inheritdoc cref="IWikiService.GetHoliday"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetHoliday()
        {
            var url = UrlHelper.CreateWikiDayFullAddress();
        }
    }
}