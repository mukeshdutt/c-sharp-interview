using xUnitExample.Services;

namespace xUnitExample.Tests.ServicesMock;

public class MockePrinterService : IPrinterService
{
    public bool IsPrinterAvailable()
    {
        return true;
    }

    public void Print(string content)
    {
        //
    }
}