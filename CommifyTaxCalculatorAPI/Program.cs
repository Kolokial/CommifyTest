using CommifyTaxCalculatorAPI.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.SetupDatabase(builder.Configuration.GetConnectionString("TaxCalculatorContextSQLite"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CommifyTaxCalculatorAPI";
    config.Title = "Commify Tax Calculator API v1";
    config.Version = "v1";
});

builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TaxCalculatorDatabaseContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseRouting();
app.MapControllers();
app.Run();