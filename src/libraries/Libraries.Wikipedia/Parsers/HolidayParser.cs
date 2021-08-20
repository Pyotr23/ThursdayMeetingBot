using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ThursdayMeetingBot.Libraries.Wikipedia.Constants;
using ThursdayMeetingBot.Libraries.Wikipedia.Models;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Parsers
{
    internal sealed class HolidayParser
    {
        private const int ListCapacity = 20;
        private readonly HtmlNodeCollection _nodes;
        private readonly List<Holiday> _allHolidays = new(ListCapacity * 3);
        private HtmlNode[] _ulNodes;
        private int _skipNodesCount = 0;

        internal List<Holiday> InternationalHolidays { get; } = new(ListCapacity);

        internal List<Holiday> PublicHolidays { get; } = new(ListCapacity);

        internal List<Holiday> NationalHolidays { get; } = new(ListCapacity);

        internal List<Holiday> AllHolidays
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
            FillUlNodes();

            FillInternationalHolidays();
            FillPublicHolidays();
            FillNationalHolidays();
        }

        private void FillUlNodes()
        {
            _ulNodes = _nodes
                .Where(n => n.Name == CssConstant.Ul)
                .ToArray();
        }

        private void FillInternationalHolidays()
        {
            if (IsNodeExists(InnerTextConstant.InternationalHolidaysNode))
                InternationalHolidays.AddRange(GetHolidays());
        }

        private void FillPublicHolidays()
        {
            if (IsNodeExists(InnerTextConstant.PublicHolidaysNode))
                PublicHolidays.AddRange(GetHolidays());
        }

        private void FillNationalHolidays()
        {
            if (IsNodeExists(InnerTextConstant.NationalHolidaysNode))
                NationalHolidays.AddRange(GetHolidays());
        }

        private bool IsNodeExists(string innerTextBeginning)
        {
            return _nodes.Any(htmlNode => htmlNode.InnerText.StartsWith(innerTextBeginning));
        }

        private IEnumerable<HtmlNode> GetHolidayNodeInnerTexts()
        {
            var ulNode = _ulNodes
                .Skip(_skipNodesCount)
                .ElementAtOrDefault(_skipNodesCount);

            if (ulNode is null)
                return Enumerable.Empty<HtmlNode>();

            _skipNodesCount++;

            return ulNode
                .ChildNodes
                .Where(n => n.Name == CssConstant.Li);
        }

        private IEnumerable<Holiday> GetHolidays()
        {
            return GetHolidayNodeInnerTexts()
                .Select(n => new Holiday(n.InnerHtml));
        }
    }
}