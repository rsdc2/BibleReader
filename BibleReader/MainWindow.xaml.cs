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

namespace BibleReader
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FlowDocument doc = new FlowDocument();

            UsxElem usx = UsxElem.FromPath("Resources/gen.usx");

            Paragraph p = new Paragraph(new Run("In the beginning was the Word."));
            doc.Blocks.Add(p);

            bibleDocReader.Document = doc;
        }
    }
}