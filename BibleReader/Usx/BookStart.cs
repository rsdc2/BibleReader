using BibleReader.Usx.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Documents;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using BibleReader.Usx.Interfaces;

namespace BibleReader.Usx
{
    public class BookStart : IUsxElement, IAtomicText, IChildOfUsx
    {
        public XElement Element { get; }
        public XNode Node { get; }
        public string Code { get => Element.Attribute("code")?.Value ?? ""; }
        public string Text { get => Element.Value; }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public BookStart(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static BookStart Create(XElement element) => new BookStart(element);
        public static BookStart Create(string code, string style, string text)
        {
            var bookStartElem = new XElement("verse", text);
            bookStartElem.SetAttributeValue("style", style);
            bookStartElem.SetAttributeValue("code", code);
            return new BookStart(bookStartElem);
        }
        public Run ToRun() => UsxRunStyle.ApplyStyle(Style)(new Run(Text));
        public IEnumerable<Run> ToRuns() => [ToRun()];
    }
}
