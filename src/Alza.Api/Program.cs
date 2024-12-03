using Alza.Persistence.Extensions;
using Asp.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
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

builder.Services.AddSwaggerGen(opt =>
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{

    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Alza Product V1");
    opt.SwaggerEndpoint("/swagger/v2/swagger.json", "Alza Product V2");
});

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
