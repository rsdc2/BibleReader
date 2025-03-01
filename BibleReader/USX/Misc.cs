using BibleReader.Usx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    internal class Misc : IUsxElement
    {
        public XElement Element { get; init; }
        public XNode Node { get; }
        public Misc(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static Misc Create(XElement element) => new Misc(element);
    }
}
