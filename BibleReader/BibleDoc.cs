using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

using System.Xml;
using System.Xml.Linq;
using BibleReader.Usx;

namespace BibleReader;

public class BibleDocReader
{


    public BibleDocReader(string path)
    {
        var reader = XmlReader.Create(path);
        reader.Read();


    }



}
