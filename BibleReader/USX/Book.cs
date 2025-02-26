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
    internal class Book : IHasXElement, IHasId, IHasStyle, IHasText
    {
        public string? Id { get; }
        public string Code { get; }
        public string Text { get; }
        public XElement Element { get; }
        public string Style { get; }
        public IEnumerable<Chapter> Chapters { get; init; }

        public Book(XElement element)
        {
            Element = element;
        }


    }
}
