using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace BibleReader.Usx;

public class UsxElement
{
    public static IUsxElement Create(XElement element) => element.Name.LocalName switch
    {
        "para" => Para.Create(element),
        "book" => BookStart.Create(element),
        "chapter" => IsStartMarker(element) ? ChapterStart.Create(element) : ChapterEnd.Create(element),
        "verse" => IsEndMarker(element) ? VerseStart.Create(element) : VerseEnd.Create(element),
        "char" => Char.Create(element),
        _ => Misc.Create(element)
    };

    public static bool IsStartMarker(XElement element) =>
        element.Attributes()
                .Select(attr => attr.Name.LocalName)
                .Contains("sid");

    public static bool IsEndMarker(XElement element) =>
    element.Attributes()
            .Select(attr => attr.Name.LocalName)
            .Contains("eid");

    public static Paragraph ToParagraph(Para para) => para.ToParagraph();

}
