using BibleReader.Usx.Interfaces;
using BibleReader.Usx.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Documents;


namespace BibleReader.Usx
{
    public class Para : IUsxElement, IHasChildren, IHasTextChildren, IHasStyle
    {
        public XNode Node { get; }
        public XElement Element { get; }
        public IEnumerable<XNode> Descendants { get => Element.DescendantNodes(); }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public IEnumerable<IAtomicText> AtomicTextNodes { 
            get => Element.DescendantNodes().Where(UsxNode.IsAtomicTextNode)
                                  .Select(node => (IAtomicText)UsxNode.Create(node)); 
        }
        public IEnumerable<IUsxElement> ChildElements { 
            get => Element.Elements().Select(UsxElement.Create); 
        }
        public IEnumerable<IUsxNode> ChildNodes {
            get => Element.Nodes().Select(UsxNode.Create);
        }
        public IEnumerable<IHasStyle> StyleNodes
        {
            get => ChildElements.Where(elem => elem.Element.Attribute("style") is not null)
                                .Select(elem => (IHasStyle)elem );
        }
        public Para(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static Para Create(XElement element) => new Para(element);
        public static Para Create(string style, IEnumerable<XNode> children)
        {
            var paraNode = new XElement("para", children);
            paraNode.SetAttributeValue("style", style);
            var para = new Para(paraNode);
            return para;
        }
        public Paragraph? ToParagraph() => Style switch
        {
            "toc1" => null,
            "toc2" => null,
            "h" => null,
            _ => _ToParagraph(),
        };
        private Paragraph _ToParagraph() 
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.AddRange(this.ToRuns());
            return UsxParaStyle.ApplyStyle(Style)(paragraph);
        }
        public IEnumerable<Run> ToRuns() => AtomicTextNodes.Select(text => text.ToRun());
        public string RunText { get => this.ToRuns().Select(run => run.Text).Aggregate(string.Concat); }
        public override string ToString() => $"Para(style='{Style}' text='{RunText}')";
    }
}
