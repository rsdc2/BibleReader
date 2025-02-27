using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibleReader.Usx.Interfaces;

namespace BibleReader.Usx
{
    internal class VerseStart : IUsxElement, IStartMarker
    {
        public string? Sid { get => Element.Attribute("sid")?.Value; }
        public string? Style { get => Element.Attribute("style")?.Value; }
        public string? Number { get => Element.Attribute("number")?.Value; }

        public XElement Element { get; init; }

        public VerseStart(XElement element) 
        {
            Element = element;
        }

        public static VerseStart Create(XElement element) => new VerseStart(element);

        public override string ToString() => $"VerseEnd(eid='{Sid}' style='{Style}' number='{Number}')";

    }
}
