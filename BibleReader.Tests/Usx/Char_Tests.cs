using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;
using BibleReader.Usx;

namespace BibleReader.Tests.Usx
{
    internal class Char_Tests
    {
        UsxDoc? _minimalWithChars;
        UsxDoc? _minimalNoChars;

        [SetUp]
        public void Setup()
        {
            _minimalWithChars = UsxDoc.CreateFromPath("Resources/MinimalWithChars.xml");
            _minimalNoChars = UsxDoc.CreateFromPath("Resources/MinimalNoChars.xml");
        }

        [Test]
        public void Test_RunFromChar_HasCorrectText()
        {
            // Arrange
            var usxChar = UsxChar.Create("w", "some");

            // Act
            var runText = usxChar.ToRuns().First().Text;

            // Assert
            Assert.That(runText, Is.EqualTo("some "));
        }

        [Test]
        public void Test_OneRun_FromOneChar()
        {
            // Arrange
            var usxChar = UsxChar.Create("w", "some");

            // Act
            var runCount = usxChar.ToRuns().Count();

            // Assert
            Assert.That(runCount, Is.EqualTo(1));
        }

        [Test]
        public void Test_Char_HasCorrectStyle()
        {
            // Arrange
            var usxChar = UsxChar.Create("w", "some");

            // Act
            var style = usxChar.Style;

            // Assert
            Assert.That(style, Is.EqualTo("w"));
        }
    }
}
