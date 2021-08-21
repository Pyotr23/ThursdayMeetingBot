using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
using ThursdayMeetingBot.Libraries.Wikipedia.Helpers;
using ThursdayMeetingBot.Libraries.Wikipedia.Models;
using ThursdayMeetingBot.Libraries.Wikipedia.Utils;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Services
{
    /// <summary>
    /// <inheritdoc cref="IWikiService"/>
    /// </summary>
    public class WikiService : IWikiService
    {
        private readonly ILogger<WikiService> _logger;

        public WikiService(ILogger<WikiService> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// <inheritdoc cref="IWikiService.GetHolidayTextAsync"/>
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetHolidayTextAsync()
        {
            _logger.LogInformation("Get holiday text");
            var holidays = await GetHolidaysAsync();
            var text = GetRandomHolidayText(holidays);
            _logger.LogInformation($"Holiday text: {text}");
            return text;
        }

        private async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            var url = UrlHelper.CreateWikiDayFullAddress();
            _logger.LogInformation($"Site page is loaded at \"{url}\"");
            var document = await new HtmlWeb().LoadFromWebAsync(url);
            _logger.LogInformation("Document is loaded");
            var parser = new HolidayParser(document);
            parser.Parse();
            return parser.AllHolidays.ToList();
        }

        private static string GetRandomHolidayText(IEnumerable<Holiday> holidays)
        {
            var holidayArray = holidays.ToArray();
            var random = new Random();
            var index = random.Next(holidayArray.Length);
            return holidayArray.ElementAtOrDefault(index)?.Text 
                   ?? string.Empty;
        }
    }
}