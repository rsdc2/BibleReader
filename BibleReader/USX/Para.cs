using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    internal class Para : IHasText, IHasStyle, IHasXElement, IHasChildren
    {
        public XElement Element { get; }

        public IEnumerable<XNode> TextNodes { get => Element.Nodes().Where(node => node.NodeType == XmlNodeType.Text); }

        public string Text { get => String.Concat(TextNodes.Select(node => ((XText)node).Value)); }

        public IEnumerable<IHasXElement> Children { get; }

        public Para(XElement element)
        {
            Element = element;
        }

        public static Para Create(XElement element) => new Para(element);
        public override string ToString() => Text;
    }
}
