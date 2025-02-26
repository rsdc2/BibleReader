using BibleReader.USFM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.USFM
{
    internal class Book : IBibleElement, IIdable
    {
        public string? Id { get; init; }
        public XElement Element { get; init; }

        public H H { get; init; }

        public 

        public Book(XElement element)
        {
            Element = element;
        }
    }
}
