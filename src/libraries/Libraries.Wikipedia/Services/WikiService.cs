using System;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
using ThursdayMeetingBot.Libraries.Wikipedia.Constants;
using ThursdayMeetingBot.Libraries.Wikipedia.Helpers;
using ThursdayMeetingBot.Libraries.Wikipedia.Parsers;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Services
{
    /// <summary>
    /// <inheritdoc cref="IWikiService"/>
    /// </summary>
    public class WikiService : IWikiService
    {
        private readonly ILogger<WikiService> _logger;
        private readonly HtmlWeb _htmlWeb = new HtmlWeb();
        
        public WikiService(ILogger<WikiService> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// <inheritdoc cref="IWikiService.GetHoliday"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> GetHolidayText()
        {
            var url = UrlHelper.CreateWikiDayFullAddress();
            var document = await _htmlWeb.LoadFromWebAsync(url);

            var contentNodes = document
                .GetElementbyId(CssConstant.ContentId)
                .FirstChild
                .ChildNodes;

            var parser = new HolidayParser(contentNodes);
            parser.Parse();
            var holidays = parser.AllHolidays;
            var random = new Random();
            var index = random.Next(holidays.Count);
            return holidays.ElementAtOrDefault(index)?.Text 
                   ?? string.Empty;
        }
    }
}