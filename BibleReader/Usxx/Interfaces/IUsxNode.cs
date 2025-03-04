using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Documents;

namespace BibleReader.Usx
{
    public interface IUsxNode
    {
        XNode Node { get; }
        IEnumerable<IUsxNode> UsxNodes { get => []; }
        IEnumerable<IUsxNode> DescendantUsxNodes { get => []; }
        IEnumerable<Run> ToRuns();
    }
}
