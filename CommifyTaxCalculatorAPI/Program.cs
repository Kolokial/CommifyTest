using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaxCalculatorDatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("TaxCalculatorContextSQLite")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CommifyTaxCalculatorAPI";
    config.Title = "Commify Tax Calculator API v1";
    config.Version = "v1";
});

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