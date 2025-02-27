using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BibleReader.Usx.Interfaces
{
    internal interface IHasText : IUsxElement
    {
        IEnumerable<XText> ChildTextNodes { get; }

        string ChildText { get; }
    }
}
