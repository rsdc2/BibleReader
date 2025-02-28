using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace BibleReader.Usx.Styles;

internal class UsxRunStyle
{
    public static Run H(Run run)
    {
        run.FontSize = 20;
        run.Typography.Capitals = FontCapitals.SmallCaps;
        return run;
    }
    public static Run Id(Run run)
    {
        run.FontSize = 20;
        run.Typography.Capitals = FontCapitals.AllSmallCaps;
        return run;
    }
    public static Run Mt1(Run run)
    {
        run.FontSize = 20;
        run.Typography.Capitals = FontCapitals.SmallCaps;
        return run;
    }
    public static Run V(Run run)
    {
        run.Text = " " + run.Text + " ";
        run.Typography.Variants = FontVariants.Superscript;
        return run;
    }
    public static Run Normal(Run run)
    {
        return run;
    }
    public static Func<Run, Run> ApplyStyle(string style) => style switch
    {
        "h" => H,
        "id" => Id,
        "mt1" => Mt1,
        "v" => V,
        _ => Normal
    };
}
