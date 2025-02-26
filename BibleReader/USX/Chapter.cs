using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    public class Chapter : IHasXElement, IHasStyle
    {
        public string Eid { get; }
        public string Style { get; }
        public string Number { get; }

        public XElement Element { get; init; }

        public Chapter(XElement element) 
        {
            Element = element;
        }
    }
}
