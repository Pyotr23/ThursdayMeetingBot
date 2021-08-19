using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
using ThursdayMeetingBot.Libraries.Wikipedia.Constants;
using ThursdayMeetingBot.Libraries.Wikipedia.Helpers;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Services
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
        public async Task<string> GetHoliday()
        {
            var url = UrlHelper.CreateWikiDayFullAddress();
            var document = await _htmlWeb.LoadFromWebAsync(url);

            var contentNodes = document
                .GetElementbyId(CssName.ContentId)
                .FirstChild
                .ChildNodes;
            
            
        }
    }
}