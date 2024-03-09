namespace xUnitExample.Tests.Controllers;

using xUnitExample.Controlles;

public class HomeControllerTest
{
    [Fact]
    public void HomeController_Index_ValidResult()
    {
        // AAA
        // Arrange
        HomeController homeController = new HomeController();
        string expectedResult = "I am in home controller.";

        // Act 
        string result = homeController.Index();

        // Assert
        Assert.Equal(expectedResult, result);
    }
}