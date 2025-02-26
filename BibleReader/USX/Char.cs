using BibleReader.USX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace BibleReader.USX
{
    internal class Char : IHasText, IHasStyle, IHasXElement
    {
        public string? Style {  }
        public XElement Element { get; }

        public Char(XElement element)
        {
            Element = element;
        }

    }
}
