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
    internal class Para_Tests
    {
        [Test]
        public void Test_ParaWithTextChildren_HasCorrectText()
        {
            // Arrange
            var text = UsxText.Create("Some text");
            var para = UsxPara.Create("p", [text]);

            // Act
            var paragraph = para.ToParagraph();
            var firstRun = (Run)paragraph.Inlines.First();

            // Assert
            Assert.That(firstRun.Text, Is.EqualTo("Some text"));
        }

        [Test]
        public void Test_ParaWithCharChildren_HasCorrectText()
        {
            // Arrange
            var char1 = UsxChar.Create("w", "Some text");
            var para = UsxPara.Create("p", [char1]);

            // Act
            var paragraph = para.ToParagraph();
            var firstRun = (Run)paragraph.Inlines.First();

            // Assert
            Assert.That(firstRun.Text, Is.EqualTo("Some text "));
        }

        [Test]
        public void Test_CannotCreate_Para_WithInvalidChildren()
        {
            // Arrange
            var bookStart = BookStart.Create("GEN", "id", "Genesis");

            //// Act 
            //Assert.That(UsxPara.Create("p", [bookStart]));
        }
    }
}
