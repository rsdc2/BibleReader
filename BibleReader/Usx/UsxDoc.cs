using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Security.AccessControl;


namespace BibleReader.Usx
{
    internal class UsxDoc : IUsxElement
    {
        public XElement Element { get; }
        public IEnumerable<IUsxElement> Children {
            get => Element.Nodes()
                            .Where(child => child.NodeType == XmlNodeType.Element)
                            .Select(element => UsxElement.Create((XElement)element));
        }

        public IEnumerable<Para> Paras
        {
            get => Children.OfType<Para>();
        }
        public UsxDoc(XElement element)
        {
            Element = element;
        }
        public static UsxDoc FromPath(string path)
        {
            var xmlDoc = XDocument.Load(path);
            XElement? rootElem = xmlDoc.Root;
            if (rootElem is null) throw new Exception("No root element");
            return new UsxDoc(rootElem);
        }


    }
}
