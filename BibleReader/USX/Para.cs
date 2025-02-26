using BibleReader.USX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.USX
{
    internal class Para : IHasText, IHasStyle, IHasXElement, IHasChildren
    {
        public XElement Element { get; }

        public IEnumerable<IHasXElement> Children { get; }

        public Para(XElement element)
        {
            Element = element;
        }
    }
}
