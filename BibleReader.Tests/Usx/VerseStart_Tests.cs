using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibleReader.Usx;

namespace BibleReader.Tests.Usx
{
    internal class VerseStart_Tests
    {

        [Test]
        public void Test_ReadsStyleCorrectly()
        {
            // Arrange
            var verseStart = VerseStart.Create("v", "1", "GEN 1:1");

            // Act
            var style = verseStart.Style;

            // Assert
            Assert.That(style, Is.EqualTo("v"));
        }

        [Test]
        public void Test_ReadsSidCorrectly()
        {
            // Arrange
            var verseStart = VerseStart.Create("v", "1", "GEN 1:1");

            // Act
            var sid = verseStart.Sid;

            // Assert
            Assert.That(sid, Is.EqualTo("GEN 1:1"));
        }

        [Test]
        public void Test_ReadsNumberCorrectly()
        {
            // Arrange
            var verseStart = VerseStart.Create("v", "1", "GEN 1:1");

            // Act
            var number = verseStart.Number;

            // Assert
            Assert.That(number, Is.EqualTo("1"));
        }
    }
}
