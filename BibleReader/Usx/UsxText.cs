using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;
using BibleReader.Usx.Styles;
using BibleReader.Usx.Interfaces;

namespace BibleReader.Usx;

internal class UsxText : IUsxNode, IAtomicText, IChildOfPara, IChildOfChar
{
    public XNode Node { get; }
    public string Style
    {
        get {
            if (Node.Parent is null) 
                throw new Exception($"Node {Node} has no parent so cannot infer style");
            return ((IHasStyle)UsxElement.Create(Node.Parent)).Style ?? "";
        }
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
    public static UsxText Create(string text) => new UsxText(new XText(text));
    public Run ToRun() => Style switch
    {
        "" => new Run(""),
        "p" => UsxRunStyle.ApplyStyle(Style)(new Run(Text)),
        "w" => UsxRunStyle.ApplyStyle(Style)(new Run(Text + " ")),
        _ => UsxRunStyle.ApplyStyle(Style)(new Run(Text))
    };
}
