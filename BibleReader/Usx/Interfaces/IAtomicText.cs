using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Documents;
namespace BibleReader.Usx
{
    public interface IAtomicText : IUsxNode, IHasStyle
    {
        string Text { get; }
        Run ToRun();
    }
}
