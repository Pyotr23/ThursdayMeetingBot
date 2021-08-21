using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ThursdayMeetingBot.Libraries.Wikipedia.Models;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Utils
{
    internal sealed class HolidayParser
    {
        private const string InternationalNodeInnerTextBeginning = "Международные";
        private const string PublicNodeInnerTextBeginning = "Общественные";
        private const string NationalNodeInnerTextBeginning = "Национальные";
        private const string ContentNodeId = "mw-content-text";
        private const int ListCapacity = 20;
        private const int ListCount = 3;

        private readonly NodeExtractor _nodeExtractor;
        
        private readonly List<Holiday> _allHolidays = new(ListCapacity * ListCount);
        private readonly List<Holiday> _internationalHolidays = new(ListCapacity);
        private readonly List<Holiday> _publicHolidays = new(ListCapacity);
        private readonly List<Holiday> _nationalHolidays = new(ListCapacity);

        internal IEnumerable<Holiday> AllHolidays
        {
            get
            {
                if (_allHolidays.Count != 0)
                    return _allHolidays;
                
                _allHolidays.AddRange(_internationalHolidays);
                _allHolidays.AddRange(_publicHolidays);
                _allHolidays.AddRange(_nationalHolidays);
                
                return _allHolidays;
            }
        }

        internal HolidayParser(HtmlDocument document)
        {
            var holidayNodes = document
                .GetElementbyId(ContentNodeId)
                .FirstChild
                .ChildNodes;
            
            _nodeExtractor = new NodeExtractor(holidayNodes);
        }

        internal void Parse()
        {
            FillInternationalHolidays();
            FillPublicHolidays();
            FillNationalHolidays();
        }

        private void FillInternationalHolidays()
        {
            if (_nodeExtractor.IsNodeExists(InternationalNodeInnerTextBeginning)) 
                _internationalHolidays.AddRange(GetHolidays());
        }

        private void FillPublicHolidays()
        {
            if (_nodeExtractor.IsNodeExists(PublicNodeInnerTextBeginning))
                _publicHolidays.AddRange(GetHolidays());
        }

        private void FillNationalHolidays()
        {
            if (_nodeExtractor.IsNodeExists(NationalNodeInnerTextBeginning))
                _nationalHolidays.AddRange(GetHolidays());
        }

        private IEnumerable<Holiday> GetHolidays()
        {
            return _nodeExtractor
                .GetLiNodes()
                .Select(htmlNode => new Holiday(htmlNode.InnerText));
        }
    }
}