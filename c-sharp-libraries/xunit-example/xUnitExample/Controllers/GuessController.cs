using Microsoft.AspNetCore.Mvc;

namespace xUnitExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuessController : ControllerBase
{
    public string Index(int guessedNumber)
    {
        if (guessedNumber < 100)
        {
            return "Wrong! Try a bigger number.";
        }
        else if (guessedNumber > 100)
        {
            return "Wrong! Try a smalled number.";
        }
        return "You guessed correct number.";
    }
}