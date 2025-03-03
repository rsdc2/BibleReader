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
    string _filePath;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoadBible(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "USX Files (*.usx)|*.usx";
        openFileDialog.FilterIndex = 0;
        if (openFileDialog.ShowDialog() == true)
        {
            _filePath = openFileDialog.FileName;
            HandleLoadBible();
        }
    }

    public void HandleLoadBible()
    {
        if (_filePath is null) return;
        
        FlowDocument doc = new FlowDocument();
        try
        {
            UsxDoc usx = UsxDoc.CreateFromPath(_filePath);
            IEnumerable<Paragraph> paras;

            if (toggleXmlView.IsChecked == true)
            {
                paras = [new Paragraph(new Run(usx.XmlText))];
            }
            else
            {
                paras = usx.Paras.Select(UsxElement.ToParagraph).OfType<Paragraph>();
            }
            doc.Blocks.AddRange(paras);
            bibleDocReader.IsTwoPageViewEnabled = true;
        }
        catch (Exception ex)
        {
            var errorMessage = Errors.LoadError(ex.Message);
            doc.Blocks.AddRange(errorMessage);
            bibleDocReader.IsTwoPageViewEnabled = false;
        }
        finally
        {
            bibleDocReader.Document = doc;
        }
    }

    public void ToggleXmlView(object sender, RoutedEventArgs e)
    {
        HandleLoadBible();
    }

}