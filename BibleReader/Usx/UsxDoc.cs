using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Security.AccessControl;


namespace BibleReader.Usx;

public class UsxDoc : IUsxElement, IHasChildren
{
    public XNode Node { get; }
    public XElement Element { get; }
    public IEnumerable<IUsxElement> ChildElements {
        get => Element.Elements().Select(UsxElement.Create);
    }
    public IEnumerable<IUsxNode> ChildNodes
    {
        get => Element.Nodes().Select(UsxNode.Create);
    }
    public IEnumerable<UsxPara> Paras
    {
        get => ChildElements.OfType<UsxPara>();
    }
    public UsxDoc(XElement element)
    {
        Element = element;
        Node = element;
    }
    public static UsxDoc CreateFromPath(string path)
    {
        var xmlDoc = XDocument.Load(path);
        XElement? rootElem = xmlDoc.Root;
        if (rootElem is null) throw new Exception("No root element");
        return new UsxDoc(rootElem);
    }
}
