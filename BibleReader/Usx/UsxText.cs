using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;

namespace BibleReader.Usx;

internal class UsxText : IUsxNode, IAtomicText
{
    public XNode Node { get; }
    public IEnumerable<XText> TextNodes {
        get => [(XText)Node];
    }
    public string Style
    {
        get => ((IHasStyle)UsxElement.Create(Node.Parent)).Style ?? "";
    }
    public string Text
    {
        get => ((XText)Node).Value;
    }
    public UsxText(XText text)
    {
        Node = text;
    }
    public static UsxText Create(XText text) => new UsxText(text);
    public Run ToRun() => new Run(Text);
}
