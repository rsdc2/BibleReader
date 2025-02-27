using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    internal class BookStart : IUsxElement
    {
        public string Code { get; }
        public string Text { get; }
        public XElement Element { get; }
        public string Style { get; }
        public IEnumerable<ChapterEnd> Chapters { get; init; }

        public BookStart(XElement element)
        {
            Element = element;
        }
        public static BookStart Create(XElement element) => new BookStart(element);

    }
}
