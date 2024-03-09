namespace xUnitExample.Tests.Controller;

public class HomeControllerTest
{
    // [Fact]
    // public void HomeController_Index_ValidResult()
    // {
    //     // AAA
    //     // Arrange
    //     HomeController homeController = new HomeController();
    //     string expectedResult = "I am home controllesr";

    //     // Act 
    //     string result = homeController.Index(100);

    //     // Assert
    //     Assert.Equal(expectedResult, result);
    // }

    [Fact]
    public void HomeController_Index_ValidateLessNumberResult()
    {
        // Arrange
        HomeController homeController = new();
        int guessedNumber = 10;
        string expectedResult = "Wrong!, Try a bigger number.";

        // Act
        string result = homeController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void HomeController_Index_ValidateGreaterNumberResult()
    {
        // Arrange
        HomeController homeController = new();
        int guessedNumber = 110;
        string expectedResult = "Wrong!, Try a smalled number.";

        // Act
        string result = homeController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void HomeController_Index_ValidateCorrectNumberResult()
    {
        // Arrange
        HomeController homeController = new();
        int guessedNumber = 100;
        string expectedResult = "You guessed correct number.";

        // Act
        string result = homeController.Index(guessedNumber);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}