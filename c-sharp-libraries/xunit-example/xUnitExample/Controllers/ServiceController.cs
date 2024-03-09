namespace xUnitExample.Controllers;

using Microsoft.AspNetCore.Mvc;
using xUnitExample.Services;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IPrinterService _printerService;

    public ServiceController(IEmailService emailService, IPrinterService printerService)
    {
        _emailService = emailService;
        _printerService = printerService;
    }

    public string Index(int guessedNumber)
    {
        string result = string.Empty;
        if (guessedNumber < 100)
        {
            result = "Wrong! Try a bigger number.";
        }
        else if (guessedNumber == 100)
        {
            result = "You guessed a correct number.";
        }
        else
        {
            result = "Wrong! Try a smaller number.";
        }
        if (_printerService.IsPrinterAvailable())
        {
            _printerService.Print("print this message");
        }
        if (_emailService.IsEmailAvailable())
        {
            _emailService.SendEmail();
        }
        return result;
    }
}