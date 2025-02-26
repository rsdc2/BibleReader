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
    internal class UsxElem : IHasXElement
    {

        public XElement Element { get; }
        public List<Para> Children { 
            get => Element.Nodes()
                            .Where(child => child.NodeType == XmlNodeType.Element)
                            .Select(element => (XElement)element)
                            .Where(element => element.Name == "para")
                            .Select(Para.Create).ToList(); 
        }

        public UsxElem(XElement element)
        {
            Element = element;
        }

        public static UsxElem FromPath(string path)
        {
            var xmlDoc = XDocument.Load(path);
            XElement? rootElem = xmlDoc.Root;
            if (rootElem is null) throw new Exception("No root element");
            return new UsxElem(rootElem);
        }
    }
}
