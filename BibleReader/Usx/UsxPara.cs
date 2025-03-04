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
    public class UsxPara : IUsxElement, IHasChildElements, IHasChildTextNodes, IHasStyle
    {
        public XNode Node { get; }
        public XElement Element { get; }
        public IEnumerable<XNode> DescendantNodes { get => Element.DescendantNodes(); }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public IEnumerable<IAtomicText> DescendantAtomicTextNodes 
        { 
            get => Element.DescendantNodes()
                          .Where(UsxNode.IsAtomicTextNode)
                          .Select(node => (IAtomicText)UsxNode.Create(node)); 
        }
        public IEnumerable<IUsxElement> UsxElements 
        { 
            get => Element.Elements().Select(UsxElement.Create); 
        }
        public IEnumerable<IUsxNode> UsxNodes 
        {
            get => Element.Nodes().Select(node => (IChildOfPara)UsxNode.Create(node));
        }
        public IEnumerable<IUsxNode> DescendantUsxNodes
        {
            get => UsxNodes.Select(node => node.DescendantUsxNodes.Prepend(node))
                           .Aggregate((acc, nodes) => acc.Concat(nodes));
        }
        public string RunText { get => this.ToRuns().Select(run => run.Text).Aggregate(string.Concat); }
        public Run XmlRun { get => new Run(Node.ToString()); }
        public UsxPara(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static UsxPara Create(XElement element) => new UsxPara(element);
        private static UsxPara Create(string style, IEnumerable<XNode> children)
        {
            var paraNode = new XElement("para", children);
            paraNode.SetAttributeValue("style", style);
            var para = new UsxPara(paraNode);
            return para;
        }
        public static UsxPara Create(string style, IEnumerable<IChildOfPara> children)
        {
            return UsxPara.Create(style, children.Select(child => child.Node));
        }
        public Paragraph? ToParagraph() => Style switch
        {
            "toc1" => null,
            "toc2" => null,
            "toc3" => null,
            "h" => null,
            _ => _ToParagraph(),
        };
        private Paragraph _ToParagraph() 
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.AddRange(this.ToRuns());
            return UsxParaStyle.ApplyStyle(Style)(paragraph);
        }
        public IEnumerable<Run> ToRuns() {
            return UsxNodes.Select(node => node.ToRuns())
                                     .Aggregate((acc, nodes) => acc.Concat(nodes));
        }
        public override string ToString() => $"UsxPara(style='{Style}' text='{RunText}')";
    }
}
