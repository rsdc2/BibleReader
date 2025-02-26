using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BibleReader.Usx.Interfaces
{
    internal interface IHasText : IHasXElement
    {
        IEnumerable<XNode> TextNodes { get => Element.Nodes().Where(node => node.NodeType == XmlNodeType.Text); }
    }
}
