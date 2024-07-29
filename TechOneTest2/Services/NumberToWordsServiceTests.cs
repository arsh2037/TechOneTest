using TechOneTest2.Services;
using Xunit;




public class NumberToWordsServiceTests
{
    private readonly NumberToWordsService _service;

    public NumberToWordsServiceTests()
    {
        _service = new NumberToWordsService();
    }

    [Fact]
    public void ConvertNumberToWords_ValidNumber_ReturnsCorrectWords()
    {
        // Arrange
        string number = "123.45";

        // Act
        string result = _service.ConvertNumberToWords(number);

        // Assert
        Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", result);
    }

    [Fact]
    public void ConvertNumberToWords_InvalidNumber_ThrowsArgumentException()
    {
        // Arrange
        string number = "invalid";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _service.ConvertNumberToWords(number));
    }
}
