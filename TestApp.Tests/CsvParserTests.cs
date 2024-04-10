using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        var csvData = string.Empty;

        // Act
        var result = CsvParser.ParseCsv(csvData);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Length);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        var csvData = "Test";

        // Act
        var result = CsvParser.ParseCsv(csvData);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Length, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("Test"));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        var csvData = "Test1,Test2,Test3";

        // Act
        var result = CsvParser.ParseCsv(csvData);

        // Assert
        Assert.That(result, Is.Not.Null.And.Property("Length").EqualTo(3).And.EquivalentTo(new[] { "Test1", "Test2", "Test3" }));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        var csvData = " Folder1 , Folder2 , Folder3 ";

        // Act
        var result = CsvParser.ParseCsv(csvData);

        // Assert
        Assert.That(result, Is.Not.Null.And.Property("Length").EqualTo(3).And.EquivalentTo(new[] { "Folder1", "Folder2", "Folder3" }));
    }
}
