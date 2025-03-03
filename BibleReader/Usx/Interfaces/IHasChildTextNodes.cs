using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BibleReader.Usx.Interfaces
{
    internal interface IHasChildTextNodes : IHasChildNodes
    {
        IEnumerable<IAtomicText> DescendantAtomicTextNodes { get; }
        IEnumerable<Run> ToRuns();
    }
}
