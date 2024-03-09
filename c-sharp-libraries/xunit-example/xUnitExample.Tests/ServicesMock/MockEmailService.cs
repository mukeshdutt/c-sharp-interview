using xUnitExample.Services;

namespace xUnitExample.Tests.ServicesMock;

public class MockEmailService : IEmailService
{
    public bool IsEmailAvailable()
    {
        return true;
    }

    public void SendEmail()
    {
        // not required
    }
}