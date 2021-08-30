using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
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
            _logger.LogInformation($"Holiday text: \"{text}\"");
            return text;
        }

        private async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            HtmlDocument document;

            try
            {
                var url = UrlCreator.CreateDayUrl();
                _logger.LogInformation($"Url for loading holidays - {url}");

                document = await new HtmlWeb().LoadFromWebAsync(url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<Holiday>();
            }

            _logger.LogInformation("Document is loaded");
            
            var parser = new HolidayParser(document);
            parser.Parse();
            
            return parser
                .AllHolidays
                .ToList();
        }

        private static string GetRandomHolidayText(IEnumerable<Holiday> holidays)
        {
            var holidayArray = holidays.ToArray();

            if (holidayArray.Length == 0)
                return string.Empty;
            
            var random = new Random();
            var index = random.Next(holidayArray.Length);
            
            return holidayArray
                .ElementAt(index)
                .Text;
        }
    }
}