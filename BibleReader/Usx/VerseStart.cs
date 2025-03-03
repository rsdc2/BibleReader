using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibleReader.Usx.Interfaces;
using BibleReader.Usx.Styles;
using System.Windows.Documents;

namespace BibleReader.Usx;

public class VerseStart : IUsxElement, IMarkerStart, IAtomicText, IChildOfPara
{
    public XElement Element { get; init; }
    public XNode Node { get; }
    public string? Sid { get => Element.Attribute("sid")?.Value; }
    public string Style { get => Element.Attribute("style")?.Value ?? ""; }
    public string Text { get => Number ?? ""; }
    public string? Number { get => Element.Attribute("number")?.Value; }
    public VerseStart(XElement element) 
    {
        Element = element;
        Node = element;
    }
    public static VerseStart Create(XElement element) => new VerseStart(element);
    public static VerseStart Create(string style, string number, string sid)
    {
        var verseStartElem = new XElement("verse");
        verseStartElem.SetAttributeValue("style", style);
        verseStartElem.SetAttributeValue("number", number);
        verseStartElem.SetAttributeValue("sid", sid);
        return new VerseStart(verseStartElem);
    }
    public Run ToRun() => UsxRunStyle.ApplyStyle(Style)(new Run(Text));
    public IEnumerable<Run> ToRuns() => [ToRun()];
    public override string ToString() => $"VerseStart(eid='{Sid}' style='{Style}' number='{Number}')";
}
