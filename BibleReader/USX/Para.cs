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
    internal class Para : IHasText, IHasStyle, IUsxElement, IHasChildren
    {
        public XElement Element { get; }

        public IEnumerable<XText> ChildTextNodes { get => Element.Nodes()
                                                        .Where(node => node.NodeType == XmlNodeType.Text)
                                                        .Select(text => (XText)text); }

        public string ChildText { get => String.Concat(ChildTextNodes.Select(text => (text.Value))); }

        public IEnumerable<IUsxElement> Children { get => Element.Elements()
                                                            .Select(UsxElement.Create); }

        public Para(XElement element)
        {
            Element = element;
        }

        public static Para Create(XElement element) => new Para(element);

        public override string ToString() => $"Para('{ChildText}')";
    }
}
