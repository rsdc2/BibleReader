using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibleReader.Usx.Interfaces;

namespace BibleReader.Usx
{
    internal class VerseEnd : IUsxElement, IEndMarker
    {
        public string? Eid { get => Element.Attribute("eid")?.Value; }
        public XElement Element { get; init; }
        public XNode Node { get; }
        public VerseEnd(XElement element) 
        {
            Element = element;
            Node = element;
        }
        public static VerseEnd Create(XElement element) => new VerseEnd(element);
        public override string ToString() => $"VerseStart(sid='{Eid}')";
    }
}
