using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;

namespace BibleReader.Usx
{
    public class ChapterStart : IUsxElement, IMarkerStart, IAtomicText, IChildOfUsx
    {
        public XElement Element { get; init; }
        public XNode Node { get; }
        public string? Number { get => Element.Attribute("number")?.Value; }
        public string? Sid { get => Element.Attribute("sid")?.Value; }
        public string? Style { get => Element.Attribute("style")?.Value; }
        public string Text { get => Number ?? ""; }
        public IEnumerable<IHasStyle> StyleNodes { get => [this]; }
        public ChapterStart(XElement element) 
        {
            Element = element;
            Node = element;
        }
        public static ChapterStart Create(XElement element) => new ChapterStart(element);
        public static ChapterStart Create(string style, string number, string sid)
        {
            var verseStartElem = new XElement("verse");
            verseStartElem.SetAttributeValue("style", style);
            verseStartElem.SetAttributeValue("number", number);
            verseStartElem.SetAttributeValue("sid", sid);
            return new ChapterStart(verseStartElem);
        }
        public Run ToRun() => new Run(Text);
        public override string ToString() => $"ChapterStart(sid='{Sid}' style='{Style}' number='{Number}')";
        public string ReaderString
        {
            get => Number ?? "";
        }
    }
}
