using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace BibleReader.Usx.Styles;

public class UsxParaStyle
{
    public static Paragraph H(Paragraph para)
    {
        para.TextAlignment = TextAlignment.Center;
        return para;
    }
    public static Paragraph Id(Paragraph para)
    {
        para.TextAlignment = TextAlignment.Center;
        return para;
    }
    public static Paragraph Mt1(Paragraph para)
    {
        para.TextAlignment = TextAlignment.Center;
        return para;
    }
    public static Paragraph Normal(Paragraph run)
    {
        return run;
    }

    public static Func<Paragraph, Paragraph> ApplyStyle(string style) => style switch
    {
        "h" => H,
        "id" => Id,
        "mt1" => Mt1,
        _ => Normal
    };
}
