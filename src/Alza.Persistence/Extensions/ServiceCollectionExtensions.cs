using Alza.Application.Repositories;
using Alza.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alza.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AlzaDbContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("Database");
            opt.UseSqlServer(connectionString);
        });

        // Inject MockProductRepository to use mock data instead. This could also be based on environment.
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}