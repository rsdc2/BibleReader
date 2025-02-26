using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BibleReader.USX.Interfaces
{
    internal interface IHasText : IHasXElement
    {
        IEnumerable<XNode> Text { get => Element.DescendantNodes().Where(node => node.NodeType == XmlNodeType.Text); }
    }
}
