using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Utils
{
    internal class NodeExtractor
    {
        private const string Ul = "ul";
        private const string Li = "li";
        
        private readonly HtmlNodeCollection _nodes;
        private readonly HtmlNode[]? _ulNodes;
        private int _skipNodesCount = 0;
        
        internal NodeExtractor(HtmlNodeCollection nodes)
        {
            _nodes = nodes;
            _ulNodes = nodes
                .Where(n => n.Name == Ul)
                .ToArray();
        }
        
        internal bool IsNodeExists(string innerTextBeginning)
        {
            return _nodes.Any(htmlNode 
                => htmlNode
                    .InnerText
                    .StartsWith(innerTextBeginning));
        }
        
        internal IEnumerable<HtmlNode> GetLiNodes()
        {
            var ulNode = _ulNodes?
                .ElementAtOrDefault(_skipNodesCount);

            if (ulNode is null)
                return Enumerable.Empty<HtmlNode>();

            _skipNodesCount++;

            return ulNode
                .ChildNodes
                .Where(n => n.Name == Li);
        }
    }
}