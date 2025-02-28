using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace BibleReader;

internal class Errors
{
    public static IEnumerable<Paragraph> LoadError(string message)
    {
        return [ErrorTitle(), ErrorMessage(message)];
    }

    public static Paragraph ErrorTitle()
    {
        var para = new Paragraph();
        var run = new Run("Unfortunately the file could not be loaded:");
        run.FontFamily = SystemFonts.StatusFontFamily;
        run.FontSize = 15;
        run.FontWeight = FontWeights.Bold;
        para.Inlines.Add(run);
        para.TextAlignment = TextAlignment.Left;
        return para;
    }

    public static Paragraph ErrorMessage(string message)
    {
        var para = new Paragraph();
        var run = new Run(message);
        run.FontFamily = SystemFonts.StatusFontFamily;
        run.FontSize = 12;
        para.Inlines.Add(run);
        para.TextAlignment = TextAlignment.Left;
        return para;
    }
}
