using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.USFM
{
    internal interface IBibleElement
    {
        public XElement? Element { get; init; }

    }
}
