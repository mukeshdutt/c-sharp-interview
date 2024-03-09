namespace xUnitExample.Services;

public interface IEmailService
{
    bool IsEmailAvailable();
    void SendEmail();
}