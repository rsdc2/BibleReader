using BibleReader.Usx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibleReader.Usx
{
    internal class Misc : IHasXElement
    {
        public XElement Element { get; init; }
    }
}
