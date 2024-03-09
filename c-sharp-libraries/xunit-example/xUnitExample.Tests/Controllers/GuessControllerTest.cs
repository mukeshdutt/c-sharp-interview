namespace xUnitExample.Tests.Controllers;

using xUnitExample.Controllers;

public class GuessControllerTest
{
    [Fact]
    public void GuessController_Index_ValidateLessNumberResult()
    {
        // Arrange
        GuessController guessController = new();
        int guessedNumber = 10;
        string expectedResult = "Wrong! Try a bigger number.";

        // Act
        string result = guessController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GuessController_Index_ValidateGreaterNumberResult()
    {
        // Arrange
        GuessController guessController = new();
        int guessedNumber = 110;
        string expectedResult = "Wrong! Try a smalled number.";

        // Act
        string result = guessController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GuessController_Index_ValidateCorrectNumberResult()
    {
        // Arrange
        GuessController guessController = new();
        int guessedNumber = 100;
        string expectedResult = "You guessed correct number.";

        // Act
        string result = guessController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}