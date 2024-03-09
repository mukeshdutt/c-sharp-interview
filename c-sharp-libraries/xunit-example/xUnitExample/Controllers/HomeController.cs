namespace xUnitExample.Controlles;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    public string Index()
    {
        return "I am in home controller.";
    }
}