using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ThursdayMeetingBot.Libraries.Wikipedia.Utils
{
    /// <summary>
    ///     Class for working with DOM nodes.
    /// </summary>
    internal class NodeExtractor
    {
        private const string Ul = "ul";
        private const string Li = "li";
        
        private readonly HtmlNodeCollection _nodes;
        private readonly HtmlNode[]? _ulNodes;
        private int _skipNodesCount = 0;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="nodes"> Collection of nodes from which need to extract information. </param>
        internal NodeExtractor(HtmlNodeCollection nodes)
        {
            _nodes = nodes;
            _ulNodes = nodes
                .Where(n => n.Name == Ul)
                .ToArray();
        }
        
        /// <summary>
        ///     Verify that the node exists.
        /// </summary>
        /// <param name="innerTextBeginning"> Beginning of the inner text. </param>
        /// <returns> True if node exists. </returns>
        internal bool IsNodeExists(string innerTextBeginning)
        {
            return _nodes.Any(htmlNode 
                => htmlNode
                    .InnerText
                    .StartsWith(innerTextBeginning));
        }
        
        /// <summary>
        ///     Get collection of "li" HTML elements.
        /// </summary>
        /// <returns></returns>
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