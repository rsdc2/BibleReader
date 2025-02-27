using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    public class ChapterStart : IUsxElement, IStartMarker
    {
        public string? Sid { get => Element.Attribute("sid")?.Value; }
        public string? Style { get => Element.Attribute("style")?.Value; }
        public string? Number { get => Element.Attribute("number")?.Value; }
        public XElement Element { get; init; }
        public ChapterStart(XElement element) 
        {
            Element = element;
        }
        public static ChapterStart Create(XElement element) => new ChapterStart(element);
        public override string ToString() => $"ChapterStart(sid='{Sid}' style='{Style}' number='{Number}')";

    }
}
