namespace xUnitExample;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
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
        else
        {
            return "You guessed correct number.";
        }
    }
}