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
        var paraCount = _minimalNoChars?.Paras.Count();

        // Assert
        Assert.That(paraCount.Equals(6));
    }
}