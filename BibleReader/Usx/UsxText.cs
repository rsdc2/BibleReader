using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;
using BibleReader.Usx.Styles;

namespace BibleReader.Usx;

internal class UsxText : IUsxNode, IAtomicText
{
    public XNode Node { get; }
    public IEnumerable<XText> TextNodes
    {
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
    public Run ToRun() => Style switch
    {
        "toc1" => new Run(""),
        "toc2" => new Run(""),
        "toc3" => new Run(""),
        "" => new Run(""),
        "p" => UsxRunStyle.ApplyStyle(Style)(new Run(Text)),
        "w" => UsxRunStyle.ApplyStyle(Style)(new Run(Text + " ")),
        _ => UsxRunStyle.ApplyStyle(Style)(new Run(Text))
    };
}
