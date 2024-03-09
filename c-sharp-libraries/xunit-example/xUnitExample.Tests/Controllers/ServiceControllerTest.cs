using xUnitExample.Services;
using xUnitExample.Tests.ServicesMock;

namespace xUnitExample.Controlles;

public class ServiceControllerTest
{
    [Fact]
    public void ServiceController_Index_ValidLargeNumber()
    {
        // Given -- Arrage
        IPrinterService printerService = new MockePrinterService();
        IEmailService emailService = new MockEmailService();

        ServiceController serviceController = new ServiceController(emailService, printerService);
        int guessedNumber = 120;
        string expectedResult = "Wrong!, Try a smalled number.";

        // When -- Act
        string result = serviceController.Index(guessedNumber);

        // Then -- Assert
        Assert.Equal(expectedResult, result);
    }
}