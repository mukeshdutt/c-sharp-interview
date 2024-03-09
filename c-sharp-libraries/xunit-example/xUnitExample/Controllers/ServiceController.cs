namespace xUnitExample.Controlles;

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
        if (guessedNumber < 100)
        {
            return "Wrong!, Try a bigger number.";
        }
        else if (guessedNumber > 100)
        {
            return "Wrong!, Try a smalled number.";
        }
        if (_printerService.IsPrinterAvailable())
        {
            _printerService.Print();
        }
        if (_emailService.IsEmailAvailable())
        {
            _emailService.SendEmail();
        }
        return "You guessed correct number.";
    }
}