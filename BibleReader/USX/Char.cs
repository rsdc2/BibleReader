using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace BibleReader.Usx
{
    internal class Char : IHasText, IUsxElement
    {
        //public string? Style {  }
        public XElement Element { get; }

        public IEnumerable<XText> ChildTextNodes
        {
            get => Element.Nodes()
                    .Where(node => node.NodeType == XmlNodeType.Text)
                    .Select(text => (XText)text);
        }

        public string ChildText { 
            get => String.Concat(ChildTextNodes.Select(text => (text.Value))); 
        }

        public Char(XElement element)
        {
            Element = element;
        }

        public static Char Create(XElement element) => new Char(element);

    }
}
