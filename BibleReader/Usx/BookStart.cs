using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Documents;

namespace BibleReader.Usx
{
    internal class BookStart : IUsxElement, IAtomicText
    {
        public XElement Element { get; }
        public XNode Node { get; }
        public string Code { get => Element.Attribute("code")?.Value ?? ""; }
        public string Text { get => Element.Value; }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public IEnumerable<ChapterEnd> Chapters { get; init; }
        public BookStart(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static BookStart Create(XElement element) => new BookStart(element);
        public Run ToRun() => new Run(Text);
    }
}
