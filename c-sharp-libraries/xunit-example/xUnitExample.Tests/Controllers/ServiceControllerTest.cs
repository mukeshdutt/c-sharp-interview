using Moq;
using xUnitExample.Services;
using xUnitExample.Controllers;
using System.Collections;

namespace xUnitExample.Tests.Controllers;

public class ServiceControllerTest
{
    [Fact]
    public void ServiceController_Index_ValidLargeNumber()
    {
        // Given -- Arrage
        // IPrinterService printerService = new MockePrinterService();
        // IEmailService emailService = new MockEmailService();

        Mock<IPrinterService> mockPrinterService = new Mock<IPrinterService>();
        mockPrinterService.Setup(x => x.IsPrinterAvailable()).Returns(true);
        mockPrinterService.Setup(x => x.Print(It.IsAny<string>())).Verifiable();

        Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.IsEmailAvailable()).Returns(true);
        mockEmailService.Setup(x => x.SendEmail()).Verifiable();

        // ServiceController serviceController = new ServiceController(emailService, printerService);
        ServiceController serviceController = new ServiceController(mockEmailService.Object, mockPrinterService.Object);
        int guessedNumber = 120;
        string expectedResult = "Wrong! Try a smaller number.";

        // When -- Act
        string result = serviceController.Index(guessedNumber);

        // Then -- Assert
        Assert.Equal(expectedResult, result);
        mockEmailService.Verify(tt => tt.SendEmail(), Times.Once());
        mockPrinterService.Verify(tt => tt.Print("print this message"), Times.Once());
    }

    [Fact]
    public void ServiceController_Index_ValidLargeNumberWithoutEmailServiceAvailableResult()
    {
        // Given -- Arrage
        // IPrinterService printerService = new MockePrinterService();
        // IEmailService emailService = new MockEmailService();

        Mock<IPrinterService> mockPrinterService = new Mock<IPrinterService>();
        mockPrinterService.Setup(x => x.IsPrinterAvailable()).Returns(false);

        Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.IsEmailAvailable()).Returns(false);
        mockEmailService.Setup(x => x.SendEmail()).Verifiable();

        // ServiceController serviceController = new ServiceController(emailService, printerService);
        ServiceController serviceController = new ServiceController(mockEmailService.Object, mockPrinterService.Object);
        int guessedNumber = 120;
        string expectedResult = "Wrong! Try a smaller number.";

        // When -- Act
        string result = serviceController.Index(guessedNumber);

        // Then -- Assert
        Assert.Equal(expectedResult, result);
        mockEmailService.Verify(tt => tt.SendEmail(), Times.Never());
    }

    [Fact]
    public void Service_Index_ValidateNumberWithException()
    {
        // - Arrange
        Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.IsEmailAvailable()).Throws(new ArgumentNullException());
        Mock<IPrinterService> mockPrinterService = new Mock<IPrinterService>();

        ServiceController serviceController = new ServiceController(mockEmailService.Object, mockPrinterService.Object);

        // Act -
        // string result = serviceController.Index(200);

        // Assert -
        Assert.Throws<ArgumentNullException>(() =>
        {
            serviceController.Index(200);
        });
    }

    [Theory]
    [InlineData(80, "Wrong! Try a bigger number.")]
    [InlineData(120, "Wrong! Try a smaller number.")]
    [InlineData(100, "You guessed a correct number.")]
    public void ServiceController_Index_ValidLargeNumberWithInlineDate(int number, string expectedResult)
    {
        // Given -- Arrage
        // IPrinterService printerService = new MockePrinterService();
        // IEmailService emailService = new MockEmailService();

        Mock<IPrinterService> mockPrinterService = new Mock<IPrinterService>();
        mockPrinterService.Setup(x => x.IsPrinterAvailable()).Returns(false);

        Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.IsEmailAvailable()).Returns(false);
        mockEmailService.Setup(x => x.SendEmail()).Verifiable();

        // ServiceController serviceController = new ServiceController(emailService, printerService);
        ServiceController serviceController = new ServiceController(mockEmailService.Object, mockPrinterService.Object);
        int guessedNumber = number;

        // When -- Act
        string result = serviceController.Index(guessedNumber);

        // Then -- Assert
        Assert.Equal(expectedResult, result);
        mockEmailService.Verify(tt => tt.SendEmail(), Times.Never());
    }

    [Theory]
    [ClassData(typeof(ValidateNumberCollection))]
    public void ServiceController_Index_ValidLargeNumberWithClassData(int number, string expectedResult)
    {
        // Given -- Arrage
        // IPrinterService printerService = new MockePrinterService();
        // IEmailService emailService = new MockEmailService();

        Mock<IPrinterService> mockPrinterService = new Mock<IPrinterService>();
        mockPrinterService.Setup(x => x.IsPrinterAvailable()).Returns(false);

        Mock<IEmailService> mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.IsEmailAvailable()).Returns(false);
        mockEmailService.Setup(x => x.SendEmail()).Verifiable();

        // ServiceController serviceController = new ServiceController(emailService, printerService);
        ServiceController serviceController = new ServiceController(mockEmailService.Object, mockPrinterService.Object);

        // When -- Act
        string result = serviceController.Index(number);

        // Then -- Assert
        Assert.Equal(expectedResult, result);
        mockEmailService.Verify(tt => tt.SendEmail(), Times.Never());
    }

    class ValidateNumberCollection : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 80, "Wrong! Try a bigger number." };
            yield return new object[] { 120, "Wrong! Try a smaller number." };
            yield return new object[] { 100, "You guessed a correct number." };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}