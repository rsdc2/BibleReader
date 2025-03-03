using BibleReader.Usx;
namespace BibleReader.Tests.Usx;

public class UsxDoc_Tests
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
    public void Test_LoadFromPath_GetsAFile()
    {
        // Arrange

        // Act
        UsxDoc doc = UsxDoc.CreateFromPath("Resources/MinimalWithChars.xml");

        // Assert
        Assert.That(doc.Element.Name.LocalName.Equals("usx"));
    }

    [Test]
    public void Test_Paras_GetsCorrectNumberOfParas()
    {
        // Arrange

        // Act
        var paraCount = _minimalNoChars?.UsxParas.Count();

        // Assert
        Assert.That(paraCount.Equals(6));
    }

    [Test]
    public void Test_ParseInvalidFile_ThrowsException()
    {
        // Arrange
        var invalidFile = UsxDoc.CreateFromPath("Resources/MinimalNoCharsInvalid.xml");

        // Act
        var paras = invalidFile.UsxParas.ToList();

        // Assert
        Assert.That(() => paras[1].ToRuns(), Throws.Exception);
    }
    [Test]
    public void Test_ParseValidFile_DoesNotThrowException()
    {
        // Arrange
        var invalidFile = UsxDoc.CreateFromPath("Resources/MinimalNoChars.xml");

        // Act
        var runText = invalidFile.UsxParas.ToList()[5].RunText;

        // Assert
        Assert.That(runText, Is.EqualTo(" 2 This is an example verse"));
    }
}