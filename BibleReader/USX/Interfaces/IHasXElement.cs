using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.USX
{
    internal interface IHasXElement
    {
        public XElement Element { get; }

    }
}
