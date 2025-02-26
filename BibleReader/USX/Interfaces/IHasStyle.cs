﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleReader.Usx
{
    internal interface IHasStyle : IHasXElement
    {
        string? Style { get => Element.Attribute("style")?.Value; }
    }
}
