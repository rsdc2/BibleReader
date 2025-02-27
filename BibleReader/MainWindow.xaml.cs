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

            UsxDoc usx = UsxDoc.FromPath("Resources/gen.usx");
            IEnumerable<Paragraph> paras = usx.Paras.Select(UsxElement.ToParagraph);
            doc.Blocks.AddRange(paras);

            bibleDocReader.Document = doc;
        }
    }
}