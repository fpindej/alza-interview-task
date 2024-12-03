namespace Alza.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void UseCustomizedSwagger(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(opt =>
        {

            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Alza Product V1");
            opt.SwaggerEndpoint("/swagger/v2/swagger.json", "Alza Product V2");
        });
    }
}