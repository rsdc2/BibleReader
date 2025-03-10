﻿using BibleReader.Usx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Documents;

namespace BibleReader.Usx
{
    public class UsxChar : IUsxElement, IHasChildElements, IHasChildTextNodes, IHasStyle, IChildOfPara
    {
        public XNode Node { get; }
        public XElement Element { get; }
        public IEnumerable<IUsxElement> UsxElements
        {
            get => Element.Elements().Select(UsxElement.Create);
        }
        public IEnumerable<IUsxNode> UsxNodes
        {
            get => Element.Nodes().Select(node => (IChildOfChar)UsxNode.Create(node));
        }
        public IEnumerable<IUsxNode> DescendantUsxNodes
        {
            get => UsxNodes.Select(node => node.DescendantUsxNodes.Prepend(node))
                           .Aggregate((acc, nodes) => acc.Concat(nodes));
        }
        public IEnumerable<IAtomicText> DescendantAtomicTextNodes
        {
            get => Element.DescendantNodes()
                          .Where(UsxNode.IsAtomicTextNode)
                          .Select(node => (IAtomicText)UsxNode.Create(node));
        }
        public string XmlText
        {
            get => Node.ToString();
        }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public UsxChar(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static UsxChar Create(XElement element) => new UsxChar(element);
        private static UsxChar Create(string style, IEnumerable<XNode> children)
        {
            var charNode = new XElement("char", children);
            charNode.SetAttributeValue("style", style);
            var usxChar = new UsxChar(charNode);
            return usxChar;
        }
        public static UsxChar Create(string style, string text)
        {
            return UsxChar.Create(style, [new XText(text)]);
        }
        public IEnumerable<Run> ToRuns() => DescendantAtomicTextNodes.Select(text => text.ToRun());
        //public IEnumerable<Run> ToXmlRuns() => ChildNodes.Select(node => node.Node.ToString());
        public Run ToRun() => new Run(RunText);
        public string RunText { get => this.ToRuns().Select(run => run.Text).Aggregate(string.Concat); }
        public override string ToString() => $"Char(style='{Style}' text='{this.RunText}')";
    }
}
