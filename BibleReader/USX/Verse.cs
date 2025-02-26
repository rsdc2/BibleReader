using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Usx
{
    internal class Verse : IHasXElement, IHasStyle
    {

        public string? Sid { get => Element.Attribute("sid")?.Value; }

        public XElement Element { get; init; }

        public Verse(XElement element) 
        { 
            Element = element;
        }

    }
}
