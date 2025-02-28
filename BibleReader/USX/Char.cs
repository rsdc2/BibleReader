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
    internal class Char : IUsxElement, IHasChildren, IHasTextChildren, IHasStyle
    {
        public XNode Node { get; }
        public XElement Element { get; }
        public IEnumerable<IAtomicText> AtomicTextNodes
        {
            get => Element.DescendantNodes().Where(UsxNode.IsAtomicTextNode)
                                  .Select(node => (IAtomicText)UsxNode.Create(node));
        }
        public IEnumerable<IUsxElement> ChildElements
        {
            get => Element.Elements().Select(UsxElement.Create);
        }
        public IEnumerable<IUsxNode> ChildNodes
        {
            get => Element.Nodes().Select(UsxNode.Create);
        }
        public IEnumerable<IHasStyle> StyleNodes
        {
            get => ChildElements.Where(elem => elem.Element.Attribute("style") is not null)
                                .Select(elem => (IHasStyle)elem);
        }
        public string Style { get => Element.Attribute("style")?.Value ?? ""; }
        public Char(XElement element)
        {
            Element = element;
            Node = element;
        }
        public static Char Create(XElement element) => new Char(element);
        public IEnumerable<Run> ToRuns() => AtomicTextNodes.Select(text => text.ToRun());
    }
}
