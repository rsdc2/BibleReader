using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Usx.Interfaces
{
    internal interface IHasChildNodes
    {
        IEnumerable<IUsxNode> ChildNodes { get; }
    }
}
