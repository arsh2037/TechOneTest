using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechOneTest2.Controllers;
using TechOneTest2.Models;
using TechOneTest2.Services;
using Xunit;

public class NumberToWordsControllerTests
{
    private readonly Mock<INumberToWordsService> _mockService;
    private readonly NumberToWordsController _controller;

    public NumberToWordsControllerTests()
    {
        _mockService = new Mock<INumberToWordsService>();
        _controller = new NumberToWordsController(_mockService.Object);
    }

    [Fact]
    public void ConvertNumberToWords_ValidNumber_ReturnsOkResult()
    {
        // Arrange
        var model = new NumberConversionModel { InputNumber = "123.45" };
        _mockService.Setup(service => service.ConvertNumberToWords("123.45"))
                    .Returns("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS");

        // Act
        var result = _controller.ConvertNumberToWords(model);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<NumberConversionModel>(okResult.Value);
        Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", returnValue.OutputWords);
    }
}
