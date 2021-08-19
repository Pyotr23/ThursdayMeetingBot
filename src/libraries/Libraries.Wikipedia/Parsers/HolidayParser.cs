using System.Collections.Generic;
using HtmlAgilityPack;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Parsers
{
    internal sealed class HolidayParser
    {
        private const int ListCapacity = 20;
        private readonly HtmlNodeCollection _nodes;
        private readonly List<string> _allHolidays = new(ListCapacity * 3);

        internal List<string> InternationalHolidays { get; private set; } = new(ListCapacity);

        internal List<string> PublicHolidays { get; private set; } = new(ListCapacity);

        internal List<string> NationalHolidays { get; private set; } = new(ListCapacity);

        internal List<string> AllHolidays
        {
            get
            {
                if (_allHolidays.Count != 0)
                    return _allHolidays;
                
                _allHolidays.AddRange(InternationalHolidays);
                _allHolidays.AddRange(PublicHolidays);
                _allHolidays.AddRange(NationalHolidays);
                return _allHolidays;
            }
        }


        internal HolidayParser(HtmlNodeCollection nodes)
        {
            _nodes = nodes;
        }

        internal void Parse()
        {
            
        }
    }
}