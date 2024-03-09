using xUnitExample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSingleton<IPrinterService, PrinterServices>();
builder.Services.AddSingleton<IEmailService, EmailService>();

var app = builder.Build();

app.MapControllers();

app.Run();