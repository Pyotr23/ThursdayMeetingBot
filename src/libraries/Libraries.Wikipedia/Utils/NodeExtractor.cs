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
        
        /// <summary>
        ///     Get collection of "li" HTML elements.
        /// </summary>
        /// <param name="node"> HTML element. </param>
        /// <returns> Collection of HTML nodes. </returns>
        internal IEnumerable<HtmlNode> GetLiNodes(HtmlNode node)
        {
            var ulNode = node
                .ChildNodes
                .FindFirst(Ul);

            if (ulNode is null)
                return Enumerable.Empty<HtmlNode>();
            
            return 
                ulNode
                .ChildNodes
                .Where(n => n.Name == Li);
        }

        /// <summary>
        ///     Checks whether the node contains a list (ul).
        /// </summary>
        /// <param name="node"> HTML node. </param>
        /// <returns> True if contains . </returns>
        internal bool HasUl(HtmlNode node)
        {
            return node
                .ChildNodes
                .Any(n => n.Name == Ul);
        }
    }
}