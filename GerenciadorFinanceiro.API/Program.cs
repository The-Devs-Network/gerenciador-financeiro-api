using GerenciadorFinanceiro.API.Modules;
using Microsoft.AspNetCore.Localization;
using Scalar.AspNetCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
           .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

builder.Services.AddApiModules(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Gerenciador Financeiro - API")
               .WithClassicLayout()
               .ForceDarkMode()
               .HideSearch()
               .ShowOperationId()
               .ExpandAllTags()
               .SortTagsAlphabetically()
               .SortOperationsByMethod()
               .PreserveSchemaPropertyOrder()
               .WithDefaultHttpClient(
                     ScalarTarget.CSharp,
                     ScalarClient.Http
                );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture),
    SupportedCultures = new[] { CultureInfo.InvariantCulture },
    SupportedUICultures = new[] { CultureInfo.InvariantCulture }
});

app.Run();
