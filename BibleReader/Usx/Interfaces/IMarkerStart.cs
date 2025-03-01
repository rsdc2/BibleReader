using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Usx.Interfaces
{
    public interface IMarkerStart : IMarker
    {
        string? Sid { get; } 
    }
}
