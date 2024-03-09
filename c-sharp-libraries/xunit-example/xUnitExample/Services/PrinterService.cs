namespace xUnitExample.Services;

public class PrinterServices : IPrinterService
{
    public bool IsPrinterAvailable()
    {
        return true;
    }

    public void Print(string content)
    {

    }
}