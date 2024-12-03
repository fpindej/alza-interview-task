using Alza.Api.Extensions;
using Alza.Api.Middlewares;
using Alza.Persistence.Extensions;
using Serilog;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;
Log.Logger = Alza.Logging.LoggerConfigurationExtensions.ConfigureMinimalLogging(environmentName);

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, _, loggerConfiguration) =>
{
    Alza.Logging.LoggerConfigurationExtensions.SetupLogger(context.Configuration, loggerConfiguration);
}, preserveStaticLogger: true);

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddApiDefinition();

var app = builder.Build();

app.UseCustomizedSwagger();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
