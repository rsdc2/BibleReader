using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.USX.Interfaces
{
    internal interface IHasChildren
    {
        IEnumerable<IHasXElement> Children { get; }
    }
}
