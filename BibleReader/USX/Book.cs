using BibleReader.USX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.USX
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
