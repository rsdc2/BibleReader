﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Usx.Interfaces
{
    internal interface IHasChildren
    {
        IEnumerable<IUsxElement> ChildElements { get; }
        IEnumerable<IUsxNode> ChildNodes { get; }   
    }
}
