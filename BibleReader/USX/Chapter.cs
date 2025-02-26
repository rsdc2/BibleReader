using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.USX
{
    internal class Chapter : IHasXElement, IHasStyle
    {
        public string Eid { get; }
        public string Style { get; }
        public string Number { get; }

        public XElement Element { get; init; }

        public IEnumerable<Verse>

        public Chapter(XElement element) 
        {
            Element = element;
        }
    }
}
