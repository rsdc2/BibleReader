using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Security.AccessControl;
using System.Windows.Documents;


namespace BibleReader.Usx;

public class UsxDoc : IUsxElement, IHasChildElements
{
    public XNode Node { get; }
    public XElement Element { get; }
    public IEnumerable<IUsxElement> UsxElements {
        get => Element.Elements().Select(UsxElement.Create);
    }
    public IEnumerable<IUsxNode> UsxNodes
    {
        get => Element.Nodes().Select(UsxNode.Create);
    }
    public IEnumerable<IUsxNode> DescendantUsxNodes 
    { 
        get => Element.DescendantNodes().Select(UsxNode.Create); 
    }
    public IEnumerable<UsxPara> UsxParas
    {
        get => UsxElements.OfType<UsxPara>();
    }
    public string XmlText { get => Node.ToString(); }
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
    public IEnumerable<Run> ToRuns()
    {
        return UsxNodes.Select(node => node.ToRuns())
                       .Aggregate((acc, nodes) => acc.Concat(nodes));
    }
}
