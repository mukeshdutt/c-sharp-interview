namespace xUnitExample.Services;

public interface IPrinterService
{
    bool IsPrinterAvailable();
    void Print();
}