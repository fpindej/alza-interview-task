using Alza.Api.Extensions;
using Alza.Api.Middlewares;
using Alza.Persistence.Extensions;
using Serilog;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;

Log.Logger = Alza.Logging.LoggerConfigurationExtensions.ConfigureMinimalLogging(environmentName);

try
{
    Log.Information("Starting web host");
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Host.UseSerilog((context, _, loggerConfiguration) =>
    {
        Alza.Logging.LoggerConfigurationExtensions.SetupLogger(context.Configuration, loggerConfiguration);
    }, preserveStaticLogger: true);

    // Add services to the container.
    try
    {
        Log.Debug("Adding persistence services");
        builder.Services.AddPersistence(builder.Configuration);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Failed to configure essential services or dependencies.");
        throw;
    }

    Log.Debug("Adding Controllers");
    builder.Services.AddControllers();

    Log.Debug("Adding Swagger for API documentation");
    builder.Services.AddApiDefinition();

    var app = builder.Build();

    Log.Debug("Configuring CORS policy to allow any origin, header, and method");
    app.UseCors(opt =>
    {
        opt.SetIsOriginAllowed(_ => true);
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
    });
    
    Log.Debug("Enabling Swagger and SwaggerUI for API documentation");
    app.UseCustomizedSwagger();

    if (app.Environment.IsDevelopment())
    {
        Log.Debug("Development environment detected; enabling Developer Exception Page");
        app.UseDeveloperExceptionPage();
        
        Log.Debug("Apply migrations to local database");
        app.ApplyMigrations();
    }

    Log.Debug("Enabling HTTPS redirection");
    app.UseHttpsRedirection();
    
    Log.Debug("Configuring request logging with Serilog");
    app.UseSerilogRequestLogging();

    Log.Debug("Adding custom exception handling middleware");
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    Log.Debug("Configuring Authorization");
    app.UseAuthorization();

    Log.Debug("Mapping controller routes");
    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Shutting down application");
    await Log.CloseAndFlushAsync();
}
