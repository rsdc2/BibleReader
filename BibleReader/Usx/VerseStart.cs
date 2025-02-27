using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibleReader.Usx.Interfaces;
using System.Windows.Documents;

namespace BibleReader.Usx
{
    internal class VerseStart : IUsxElement, IStartMarker, IAtomicText
    {
        public XElement Element { get; init; }
        public XNode Node { get; }
        public string? Sid { get => Element.Attribute("sid")?.Value; }
        public string? Style { get => Element.Attribute("style")?.Value; }
        public IEnumerable<IHasStyle> StyleNodes {
            get => [this];
        }
        public string Text { get => Number ?? ""; }
        public string? Number { get => Element.Attribute("number")?.Value; }
        public VerseStart(XElement element) 
        {
            Element = element;
            Node = element;
        }
        public static VerseStart Create(XElement element) => new VerseStart(element);
        public Run ToRun() 
        {
            var run = new Run(" " + Text + " ");
            run.Typography.Variants = FontVariants.Superscript;
            return run;
        }
        public override string ToString() => $"VerseEnd(eid='{Sid}' style='{Style}' number='{Number}')";
        public string ReaderString { get => Number ?? ""; }
    }
}
