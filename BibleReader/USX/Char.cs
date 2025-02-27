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
    internal class Char : IUsxElement
    {
        public XNode Node { get; }
        public XElement Element { get; }
        public string Style { get => throw new NotImplementedException(); }
        public IEnumerable<XText> TextNodes
        {
            get => Element.Nodes()
                    .Where(node => node.NodeType == XmlNodeType.Text)
                    .Select(text => (XText)text);
        }
        public string Text { 
            get => TextNodes.Select(text => (text.Value)).Aggregate(String.Concat); 
        }
        public Char(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static Char Create(XElement element) => new Char(element);

        public string ReaderString { get => Text; }
    }
}
