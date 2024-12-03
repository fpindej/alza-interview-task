using Asp.Versioning;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Protocols.Configuration;
using Microsoft.OpenApi.Models;
using Environments = Alza.Logging.Environments;

namespace Alza.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiDefinition(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Alza Product V1",
                Description = "Alza Product API to work with products.",
                Version = "v1"
            });
    
            opt.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Alza Product V2",
                Description = "Alza Product API to work with products.",
                Version = "v1"
            });
    
            opt.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

        return services;
    }

    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck("Web API", () => HealthCheckResult.Healthy("App is running"), new[] { "ready", "api" })
            .AddSqlServer(
                configuration.GetConnectionString("Database") ?? throw new InvalidConfigurationException("Missing DB connection string."),
                name: "SQL Server",
                tags: new[] { "ready", "database" }
            );

        return services;
    }
}