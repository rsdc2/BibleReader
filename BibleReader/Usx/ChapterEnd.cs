using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    public class ChapterEnd : IUsxElement, IEndMarker
    {
        public string? Eid { get => Element.Attribute("eid")?.Value; }
        public XElement Element { get; init; }
        public ChapterEnd(XElement element) 
        {
            Element = element;
        }
        public static ChapterEnd Create(XElement element) => new ChapterEnd(element);
        public override string ToString() => 
            $"ChapterEnd(sid='{Eid}')";
    }
}
