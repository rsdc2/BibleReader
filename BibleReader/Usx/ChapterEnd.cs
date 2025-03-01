using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    public class ChapterEnd : IUsxElement, IMarkerEnd, IChildOfUsx
    {
        public string? Eid { get => Element.Attribute("eid")?.Value; }
        public XElement Element { get; init; }
        public XNode Node { get; }
        public ChapterEnd(XElement element) 
        {
            Element = element;
            Node = element;
        }
        public static ChapterEnd Create(XElement element) => new ChapterEnd(element);
        public static ChapterEnd Create(string eid)
        {
            var chapterEndElem = new XElement("chapter");
            chapterEndElem.SetAttributeValue("eid", eid);
            return new ChapterEnd(chapterEndElem);
        }
        public override string ToString() => 
            $"ChapterEnd(sid='{Eid}')";
    }
}
