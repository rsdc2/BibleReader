using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace BibleReader.Usx
{
    internal class UsxNode
    {
        public static IUsxNode Create(XNode node) => node.NodeType switch
        {
            XmlNodeType.Element => UsxElement.Create((XElement)node),
            XmlNodeType.Text => UsxText.Create((XText)node),
            _ => throw new Exception("Cannot create UsxNode from node " + node.ToString())
        };

        public static bool IsAtomicTextNode(XNode node) => node.NodeType switch
        {
            XmlNodeType.Element => UsxElement.IsAtomicTextElement((XElement)node),
            XmlNodeType.Text => true,
            _ => false
        };
    }
}
