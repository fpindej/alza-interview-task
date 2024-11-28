using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Alza.Persistence.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AlzaDbContext>();

        dbContext.Database.Migrate();
    }
}