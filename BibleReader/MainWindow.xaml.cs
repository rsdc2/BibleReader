using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BibleReader.Usx;
using Microsoft.Win32;

namespace BibleReader;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnOpenFileDlg_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "USX Files (*.usx)|*.usx";
        openFileDialog.FilterIndex = 0;
        if (openFileDialog.ShowDialog() == true)
        {
            UsxDoc usx = UsxDoc.FromPath("Resources/tnt/mat.usx");
            var paras = usx.Paras.Select(UsxElement.ToParagraph).OfType<Paragraph>();
            FlowDocument doc = new FlowDocument();
            doc.Blocks.AddRange(paras);
            bibleDocReader.Document = doc;
        }

    }
}